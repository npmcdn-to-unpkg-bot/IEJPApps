using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using IEJPApps.Models;

namespace IEJPApps.Extensions
{
    public static class IdentityExtensions
    {
        public static CultureInfo GetCurrentCulture(this IPrincipal principal)
        {
            return Thread.CurrentThread.CurrentUICulture;
        }

        public static void SetCurrentCulture(this IPrincipal principal, string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
        }

        public static bool IsCultureEnglish(this IPrincipal principal)
        {
            return GetCurrentCulture(principal).TwoLetterISOLanguageName.ToLower() == "en";
        }

        public static bool IsCultureFrench(this IPrincipal principal)
        {
            return GetCurrentCulture(principal).TwoLetterISOLanguageName.ToLower() == "fr";
        }

        public static string GetEmployeeId(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst("EmployeeId");
            return claim == null ? null : claim.Value;
        }

        public static string GetEmployeeName(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst("EmployeeName");
            return claim == null ? null : claim.Value;
        }

        public static bool IsAdmin(this IPrincipal principal)
        {
            return principal.IsInRole(UserRoles.Admin);
        }

        public static bool IsEmployee(this IPrincipal principal)
        {
            return principal.IsInRole(UserRoles.Employee);
        }
    }
}