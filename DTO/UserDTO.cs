using DM_OHD.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DM_OHD.DTO
{
    public class UserDTO
    {
        public bool Login(string userId, string password)
        {
            DataTable dt = DBUtils.GetData(
                "SELECT USER_ID, FULL_NAME FROM APP_USER WHERE USER_ID=@USER_ID AND PASSWORD_MD5=@PWD AND IS_ACTIVE=1",
                new SqlParameter("@USER_ID", userId),
                new SqlParameter("@PWD", Constaint.ToMd5(password)));

            if (dt.Rows.Count == 0)
            {
                return false;
            }

            Constaint.CurrentUserId = Convert.ToString(dt.Rows[0]["USER_ID"]);
            Constaint.CurrentUserName = Convert.ToString(dt.Rows[0]["FULL_NAME"]);

            DataTable roleTable = DBUtils.GetData(
                "SELECT ROLE_CODE FROM APP_USER_ROLE WHERE USER_ID=@USER_ID",
                new SqlParameter("@USER_ID", userId));

            HashSet<string> roles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow row in roleTable.Rows)
            {
                roles.Add(Convert.ToString(row["ROLE_CODE"]));
            }
            Constaint.CurrentRoles = roles;

            return true;
        }

        public DataTable GetUsers()
        {
            return DBUtils.GetData(@"SELECT u.USER_ID, u.FULL_NAME, ISNULL(u.EMAIL,'') AS EMAIL, u.IS_ACTIVE,
                                    STUFF((SELECT ',' + ur.ROLE_CODE FROM APP_USER_ROLE ur WHERE ur.USER_ID=u.USER_ID FOR XML PATH('')),1,1,'') AS ROLES
                                    FROM APP_USER u ORDER BY u.USER_ID");
        }

        public DataTable GetRoles()
        {
            return DBUtils.GetData("SELECT ROLE_CODE, ROLE_NAME FROM APP_ROLE ORDER BY ROLE_CODE");
        }

        public void SaveUser(string userId, string fullName, string email, string password, bool isActive, List<string> roles)
        {
            object exists = DBUtils.ExecScalar("SELECT COUNT(1) FROM APP_USER WHERE USER_ID=@USER_ID", new SqlParameter("@USER_ID", userId));
            if (Convert.ToInt32(exists) == 0)
            {
                DBUtils.Exec("INSERT INTO APP_USER(USER_ID,FULL_NAME,EMAIL,PASSWORD_MD5,IS_ACTIVE) VALUES(@USER_ID,@FULL_NAME,@EMAIL,@PWD,@ACTIVE)",
                    new SqlParameter("@USER_ID", userId),
                    new SqlParameter("@FULL_NAME", fullName),
                    new SqlParameter("@EMAIL", email ?? string.Empty),
                    new SqlParameter("@PWD", Constaint.ToMd5(password)),
                    new SqlParameter("@ACTIVE", isActive));
            }
            else
            {
                string update = string.IsNullOrWhiteSpace(password)
                    ? "UPDATE APP_USER SET FULL_NAME=@FULL_NAME, EMAIL=@EMAIL, IS_ACTIVE=@ACTIVE WHERE USER_ID=@USER_ID"
                    : "UPDATE APP_USER SET FULL_NAME=@FULL_NAME, EMAIL=@EMAIL, PASSWORD_MD5=@PWD, IS_ACTIVE=@ACTIVE WHERE USER_ID=@USER_ID";

                if (string.IsNullOrWhiteSpace(password))
                {
                    DBUtils.Exec(update,
                        new SqlParameter("@USER_ID", userId),
                        new SqlParameter("@FULL_NAME", fullName),
                        new SqlParameter("@EMAIL", email ?? string.Empty),
                        new SqlParameter("@ACTIVE", isActive));
                }
                else
                {
                    DBUtils.Exec(update,
                        new SqlParameter("@USER_ID", userId),
                        new SqlParameter("@FULL_NAME", fullName),
                        new SqlParameter("@EMAIL", email ?? string.Empty),
                        new SqlParameter("@PWD", Constaint.ToMd5(password)),
                        new SqlParameter("@ACTIVE", isActive));
                }
            }

            DBUtils.Exec("DELETE FROM APP_USER_ROLE WHERE USER_ID=@USER_ID", new SqlParameter("@USER_ID", userId));
            foreach (string role in roles)
            {
                DBUtils.Exec("INSERT INTO APP_USER_ROLE(USER_ID,ROLE_CODE) VALUES(@USER_ID,@ROLE)",
                    new SqlParameter("@USER_ID", userId),
                    new SqlParameter("@ROLE", role));
            }
        }

        public void ChangePassword(string userId, string oldPassword, string newPassword)
        {
            object count = DBUtils.ExecScalar("SELECT COUNT(1) FROM APP_USER WHERE USER_ID=@U AND PASSWORD_MD5=@P",
                new SqlParameter("@U", userId),
                new SqlParameter("@P", Constaint.ToMd5(oldPassword)));
            if (Convert.ToInt32(count) == 0)
            {
                throw new Exception("Mật khẩu cũ không đúng.");
            }

            DBUtils.Exec("UPDATE APP_USER SET PASSWORD_MD5=@P WHERE USER_ID=@U",
                new SqlParameter("@U", userId),
                new SqlParameter("@P", Constaint.ToMd5(newPassword)));
        }
    }
}
