using System.Data;
using System.Data.SqlClient;

namespace JigFlow.Data
{
    public class UserManagementService
    {
        public DataTable GetUsers()
        {
            const string SQL_QUERY = @"SELECT USER_ID, USERNAME, FULL_NAME, ROLE_CODE, EMAIL, IS_ACTIVE, CREATED_AT, UPDATED_AT
                                       FROM dbo.USERS
                                       ORDER BY USERNAME";
            return DbUtils.GetData(SQL_QUERY);
        }

        public int SaveUser(string USERNAME, string FULL_NAME, string ROLE_CODE, string EMAIL, bool IS_ACTIVE, string RAW_PASSWORD)
        {
            const string SQL_QUERY = @"
IF EXISTS (SELECT 1 FROM dbo.USERS WHERE USERNAME = @USERNAME)
BEGIN
    UPDATE dbo.USERS
    SET FULL_NAME = @FULL_NAME,
        ROLE_CODE = @ROLE_CODE,
        EMAIL = @EMAIL,
        IS_ACTIVE = @IS_ACTIVE,
        UPDATED_AT = GETDATE()
    WHERE USERNAME = @USERNAME
END
ELSE
BEGIN
    INSERT INTO dbo.USERS(USERNAME, FULL_NAME, PASSWORD_HASH, ROLE_CODE, EMAIL, IS_ACTIVE, CREATED_AT)
    VALUES(@USERNAME, @FULL_NAME, @PASSWORD_HASH, @ROLE_CODE, @EMAIL, @IS_ACTIVE, GETDATE())
END";

            return DbUtils.Execute(SQL_QUERY,
                new SqlParameter("@USERNAME", USERNAME),
                new SqlParameter("@FULL_NAME", FULL_NAME),
                new SqlParameter("@PASSWORD_HASH", AppSession.Md5(RAW_PASSWORD)),
                new SqlParameter("@ROLE_CODE", ROLE_CODE),
                new SqlParameter("@EMAIL", EMAIL),
                new SqlParameter("@IS_ACTIVE", IS_ACTIVE));
        }
    }
}
