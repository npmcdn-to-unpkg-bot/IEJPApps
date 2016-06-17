using System.Web;
using IEJPApps.Models;
using IEJPApps.Services.Interfaces;

namespace IEJPApps.Services
{
    public class CookieService : ICookieService
    {
        private const string CookieName = "_user";

        public string Language { get; set; }
        public string Role { get; set; }

        public void Save()
        {
            var cookie = HttpContext.Current.Request.Cookies[CookieName] ?? new HttpCookie(CookieName);

            cookie.Values["Language"] = Language;
            cookie.Values["Role"] = Role;

            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public void Load()
        {
            var cookie = HttpContext.Current.Request.Cookies[CookieName] ?? new HttpCookie(CookieName);

            Language = cookie.Values["Language"] ?? "fr";
            Role = cookie.Values["Role"] ?? UserRoles.Employee;
        }
    }
}