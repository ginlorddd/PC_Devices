using JigFlow.DTO;
using System;
using System.Data.SqlClient;

namespace JigFlow.Data
{
    public class AuthService
    {
        public UserDto Login(string USERNAME, string PASSWORD)
        {
            const string SQL_QUERY = @"SELECT TOP 1 USER_ID, USERNAME, FULL_NAME, ROLE_CODE, EMAIL, IS_ACTIVE, PASSWORD_HASH
                                       FROM dbo.USERS
                                       WHERE USERNAME = @USERNAME";

            var DT_RESULT = DbUtils.GetData(SQL_QUERY, new SqlParameter("@USERNAME", USERNAME));
            if (DT_RESULT.Rows.Count == 0)
            {
                return null;
            }

            var USER_ROW = DT_RESULT.Rows[0];
            if (!Convert.ToBoolean(USER_ROW["IS_ACTIVE"]))
            {
                return null;
            }

            var HASH_PASSWORD = Convert.ToString(USER_ROW["PASSWORD_HASH"]);
            if (!string.Equals(HASH_PASSWORD, AppSession.Md5(PASSWORD), StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var USER_DTO = new UserDto
            {
                UserId = Convert.ToInt32(USER_ROW["USER_ID"]),
                Username = Convert.ToString(USER_ROW["USERNAME"]),
                FullName = Convert.ToString(USER_ROW["FULL_NAME"]),
                RoleCode = Convert.ToString(USER_ROW["ROLE_CODE"]),
                Email = Convert.ToString(USER_ROW["EMAIL"]),
                IsActive = Convert.ToBoolean(USER_ROW["IS_ACTIVE"])
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

            const string SQL_QUERY = @"UPDATE dbo.USERS
                                       SET PASSWORD_HASH = @NEW_HASH,
                                           UPDATED_AT = GETDATE()
                                       WHERE USERNAME = @USERNAME
                                         AND PASSWORD_HASH = @CURRENT_HASH";

            var AFFECTED_ROWS = DbUtils.Execute(SQL_QUERY,
                new SqlParameter("@NEW_HASH", NEW_HASH),
                new SqlParameter("@USERNAME", USERNAME),
                new SqlParameter("@CURRENT_HASH", CURRENT_HASH));

            if (AFFECTED_ROWS > 0)
            {
                AppSession.PasswordHash = NEW_HASH;
                return true;
            }

            return false;
        }
    }
}
