using JigFlow.DTO;
using System;
using System.Data.SqlClient;

namespace JigFlow.Data
{
    public class AuthService
    {
        public UserDto Login(string USERNAME, string PASSWORD)
        {
            const string SQL_QUERY = @"SELECT TOP 1 UserId, Username, FullName, RoleCode, Email, IsActive, PasswordHash
                                 FROM dbo.Users
                                 WHERE Username = @Username";

            var DT_RESULT = DbUtils.GetData(SQL_QUERY, new SqlParameter("@Username", USERNAME));
            if (DT_RESULT.Rows.Count == 0)
            {
                return null;
            }

            var USER_ROW = DT_RESULT.Rows[0];
            if (!(bool)USER_ROW["IsActive"]) return null;

            var HASH_PASSWORD = Convert.ToString(USER_ROW["PasswordHash"]);
            if (!string.Equals(HASH_PASSWORD, AppSession.Md5(PASSWORD), StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var USER_DTO = new UserDto
            {
                UserId = Convert.ToInt32(USER_ROW["UserId"]),
                Username = Convert.ToString(USER_ROW["Username"]),
                FullName = Convert.ToString(USER_ROW["FullName"]),
                RoleCode = Convert.ToString(USER_ROW["RoleCode"]),
                Email = Convert.ToString(USER_ROW["Email"]),
                IsActive = Convert.ToBoolean(USER_ROW["IsActive"])
            };

            AppSession.UserId = USER_DTO.Username;
            AppSession.FullName = USER_DTO.FullName;
            AppSession.RoleCode = USER_DTO.RoleCode;
            AppSession.PasswordHash = HASH_PASSWORD;

            return USER_DTO;
        }

        public bool ChangePassword(string USERNAME, string CURRENT_PASSWORD, string NEW_PASSWORD)
        {
            var CURRENT_HASH = AppSession.Md5(CURRENT_PASSWORD);
            var NEW_HASH = AppSession.Md5(NEW_PASSWORD);

            const string SQL_QUERY = @"UPDATE dbo.Users
                                 SET PasswordHash = @NewHash, UpdatedAt = GETDATE()
                                 WHERE Username = @Username AND PasswordHash = @CurrentHash";

            var AFFECTED_ROWS = DbUtils.Execute(SQL_QUERY,
                new SqlParameter("@NewHash", NEW_HASH),
                new SqlParameter("@Username", USERNAME),
                new SqlParameter("@CurrentHash", CURRENT_HASH));

            if (AFFECTED_ROWS > 0)
            {
                AppSession.PasswordHash = NEW_HASH;
                return true;
            }

            return false;
        }
    }
}
