using System.Data.Entity.Migrations;

namespace IEJPApps.Migrations
{
    // Commandes pour la mise a jour du modele
    // 
    // 1- Add-Migration XYZ. can re-use (aka scaffold) ex: Add-Migration V1... Add-Migration V2
    // 2- Update-Database
    //
    internal sealed class Configuration : DbMigrationsConfiguration<IEJPApps.Models.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(IEJPApps.Models.Infrastructure.ApplicationDbContext context)
        {
            ConfigurationSeeds.SeedAspNetUsers(context);
            ConfigurationSeeds.SeedProjects(context);
        }
    }
}
