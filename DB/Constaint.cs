using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PC_Devices.DB
{
    public static class Constaint
    {
        public static string CurrentUserId;
        public static string CurrentUserName;
        public static HashSet<string> CurrentRoles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public static string ToMd5(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(text ?? string.Empty));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static bool HasRole(string roleCode)
        {
            return CurrentRoles.Contains(roleCode);
        }

        public static bool IsAdmin()
        {
            return CurrentRoles.Contains("ADMIN");
        }
    }
}
