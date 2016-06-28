using System;
using System.Web;
using IEJPApps.Models;

namespace IEJPApps.Services
{
    public class CookieService : ICookieService
    {
        private const string UserCookieName = "IEJP_User";
        private const string CultureCookieName = "IEJP_UserCulture";
        private const string SessionCookieName = "ASP.NET_SessionId";

        /// <summary>
        /// Doit etre 'live' et non pas loader dans le constructeur...
        /// </summary>
        private HttpCookie UserCookie
        {
            get
            {
                return HttpContext.Current.Request.Cookies[UserCookieName] ?? new HttpCookie(UserCookieName);
            }
        }

        private HttpCookie CultureCookie
        {
            get
            {
                return HttpContext.Current.Request.Cookies[CultureCookieName] ?? new HttpCookie(CultureCookieName);
            }
        }

        private HttpCookie SessionCookie
        {
            get
            {
                return HttpContext.Current.Request.Cookies[SessionCookieName] ?? new HttpCookie(SessionCookieName);
            }
        }

        public string Language
        {
            get { return CultureCookie.Values["Language"] ?? "fr"; }
            set
            {
                CultureCookie.Values["Language"] = value;
                Save(CultureCookie);
            }
        }

        public string Role
        {
            get { return UserCookie.Values["Role"] ?? UserRoles.Employee; }
            set
            {
                UserCookie.Values["Role"] = value;
                Save(UserCookie);
            }
        }

        public Guid EmployeeId
        {
            get { return new Guid(UserCookie.Values["EmployeeId"]); }
            set
            {
                UserCookie.Values["EmployeeId"] = value.ToString();
                Save(UserCookie);
            }
        }

        public string SessionId
        {
            get { return SessionCookie.Value; }
        }
        
        protected void Save(HttpCookie cookie)
        {
            if (cookie != null)
                HttpContext.Current.Response.AppendCookie(cookie);
        }
        
        public void Clear()
        {
            HttpContext.Current.Response.Cookies.Remove(UserCookieName);
        }
    }
}