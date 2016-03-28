using Microsoft.AspNet.Identity.EntityFramework;

namespace IEJPApps.Models.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Project> Projects { get; set; }
        public System.Data.Entity.DbSet<Employee> Employees { get; set; }
        public System.Data.Entity.DbSet<TimeTransaction> TimeTransactions { get; set; }
        public System.Data.Entity.DbSet<ExpenditureTransaction> ExpenditureTransactions { get; set; }
    }
}