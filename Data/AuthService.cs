using JigFlow.DTO;
using System;
using System.Data.SqlClient;

namespace JigFlow.Data
{
    public class AuthService
    {
        public UserDto Login(string username, string password)
        {
            const string sql = @"SELECT TOP 1 UserId, Username, FullName, RoleCode, Email, IsActive, PasswordHash
                                 FROM dbo.Users
                                 WHERE Username = @Username";
            var dt = DbUtils.GetData(sql, new SqlParameter("@Username", username));
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            var row = dt.Rows[0];
            if (!(bool)row["IsActive"]) return null;

            var hash = Convert.ToString(row["PasswordHash"]);
            if (!string.Equals(hash, AppSession.Md5(password), StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var user = new UserDto
            {
                UserId = Convert.ToInt32(row["UserId"]),
                Username = Convert.ToString(row["Username"]),
                FullName = Convert.ToString(row["FullName"]),
                RoleCode = Convert.ToString(row["RoleCode"]),
                Email = Convert.ToString(row["Email"]),
                IsActive = Convert.ToBoolean(row["IsActive"])
            };

            AppSession.UserId = user.Username;
            AppSession.FullName = user.FullName;
            AppSession.RoleCode = user.RoleCode;
            AppSession.PasswordHash = hash;

            return user;
        }

        public bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            var currentHash = AppSession.Md5(currentPassword);
            var newHash = AppSession.Md5(newPassword);

            const string sql = @"UPDATE dbo.Users
                                 SET PasswordHash = @NewHash, UpdatedAt = GETDATE()
                                 WHERE Username = @Username AND PasswordHash = @CurrentHash";

            var affected = DbUtils.Execute(sql,
                new SqlParameter("@NewHash", newHash),
                new SqlParameter("@Username", username),
                new SqlParameter("@CurrentHash", currentHash));

            if (affected > 0)
            {
                AppSession.PasswordHash = newHash;
                return true;
            }

            return false;
        }
    }
}
