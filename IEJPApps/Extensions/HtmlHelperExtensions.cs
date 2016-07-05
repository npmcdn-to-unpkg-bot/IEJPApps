using System;
using System.Web;
using System.Web.Mvc;
using IEJPApps.Models;
using IEJPApps.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IEJPApps.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static EnvironmentViewModel GetEnvironment(this HtmlHelper htmlHelper)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var currentUser = HttpContext.Current.User;

                var environment = new EnvironmentViewModel
                {
                    UserId = currentUser.Identity.GetUserId() ?? string.Empty,
                    EmployeeId = currentUser.GetEmployeeId(),
                    EmployeeName = currentUser.GetEmployeeName(),
                    IsActive = currentUser.IsActive(),
                    IsVisible = currentUser.IsVisible(),
                    IsAdmin = currentUser.IsInRole(UserRoles.Admin),
                    IsEmployee = currentUser.IsInRole(UserRoles.Employee),
                };
                
                return environment;
            }

            return null;
        }

        public static IHtmlString ToJson<T>(this T obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return MvcHtmlString.Create(JsonConvert.SerializeObject(obj, settings));
        }
    }
}