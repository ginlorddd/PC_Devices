using System.Data;
using System.Data.SqlClient;

namespace JigFlow.Data
{
    public class UserManagementService
    {
        public DataTable GetUsers()
        {
            const string SQL_QUERY = @"SELECT UserId, Username, FullName, RoleCode, Email, IsActive, CreatedAt, UpdatedAt
                                 FROM dbo.Users ORDER BY Username";
            return DbUtils.GetData(SQL_QUERY);
        }

        public int SaveUser(string username, string fullName, string roleCode, string email, bool isActive, string rawPassword)
        {
            const string SQL_QUERY = @"
IF EXISTS (SELECT 1 FROM dbo.Users WHERE Username = @Username)
BEGIN
    UPDATE dbo.Users
    SET FullName = @FullName,
        RoleCode = @RoleCode,
        Email = @Email,
        IsActive = @IsActive,
        UpdatedAt = GETDATE()
    WHERE Username = @Username
END
ELSE
BEGIN
    INSERT INTO dbo.Users(Username, FullName, PasswordHash, RoleCode, Email, IsActive, CreatedAt)
    VALUES(@Username, @FullName, @PasswordHash, @RoleCode, @Email, @IsActive, GETDATE())
END";

            return DbUtils.Execute(SQL_QUERY,
                new SqlParameter("@Username", username),
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@PasswordHash", AppSession.Md5(rawPassword)),
                new SqlParameter("@RoleCode", roleCode),
                new SqlParameter("@Email", email),
                new SqlParameter("@IsActive", isActive));
        }
    }
}
