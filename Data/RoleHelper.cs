using System;

namespace JigFlow.Data
{
    public static class RoleHelper
    {
        public const string SYSTEM_ADMIN = "SYSTEM_ADMIN";
        public const string APPROVER = "APPROVER";
        public const string MEMBER = "MEMBER";

        public static bool IsSystemAdmin()
        {
            return string.Equals(AppSession.RoleCode, SYSTEM_ADMIN, StringComparison.OrdinalIgnoreCase)
                   || string.Equals(AppSession.RoleCode, "ADMIN", StringComparison.OrdinalIgnoreCase);
        }

        public static bool CanApprove()
        {
            return IsSystemAdmin() || string.Equals(AppSession.RoleCode, APPROVER, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsLoggedIn() => !string.IsNullOrWhiteSpace(AppSession.UserId);
    }
}
