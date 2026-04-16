using System.Security.Cryptography;
using System.Text;

namespace JigFlow.Data
{
    public static class AppSession
    {
        public static string UserId { get; set; }
        public static string FullName { get; set; }
        public static string RoleCode { get; set; }
        public static string PasswordHash { get; set; }

        public static void Clear()
        {
            UserId = string.Empty;
            FullName = string.Empty;
            RoleCode = string.Empty;
            PasswordHash = string.Empty;
        }

        public static string Md5(string input)
        {
            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(input ?? string.Empty));
                var sb = new StringBuilder();
                foreach (var b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
