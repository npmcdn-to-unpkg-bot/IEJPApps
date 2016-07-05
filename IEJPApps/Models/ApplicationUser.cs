using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IEJPApps.Models.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IEJPApps.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            var employee = new EmployeeRepository().GetEmployee(new Guid(this.Id));
            if (employee != null)
            {
                userIdentity.AddClaim(new Claim("EmployeeId", employee.Id.ToString()));
                userIdentity.AddClaim(new Claim("EmployeeName", employee.FullName));
                userIdentity.AddClaim(new Claim("Active", employee.Active.ToString()));
                userIdentity.AddClaim(new Claim("Visible", employee.Visible.ToString()));
            }

            return userIdentity;
        }
    }
}