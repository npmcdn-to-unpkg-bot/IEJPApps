using System.Globalization;
using System.Security.Principal;
using IEJPApps.Models;

namespace IEJPApps.Extensions
{
    public static class IdentityExtensions
    {
        public static CultureInfo GetCurrentCulture(this IPrincipal principal)
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture;
        }

        public static void SetCurrentCulture(this IPrincipal principal, string language)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(language);
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
        }

        public static bool IsCultureEnglish(this IPrincipal principal)
        {
            return GetCurrentCulture(principal).TwoLetterISOLanguageName.ToLower() == "en";
        }

        public static bool IsCultureFrench(this IPrincipal principal)
        {
            return GetCurrentCulture(principal).TwoLetterISOLanguageName.ToLower() == "fr";
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