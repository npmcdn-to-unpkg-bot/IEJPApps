using IEJPApps.Models;
using System;
using System.Data.Entity.Migrations;

namespace IEJPApps.Migrations
{
    // Commandes pour la mise a jour du modele
    // 
    // 1- Add-Migration XYZ
    // 2- Update-Database
    //
    internal static class ConfigurationSeeds
    {
        public static void SeedAspNetUsers(IEJPApps.Models.Infrastructure.ApplicationDbContext context)
        {
            //if (!context.Users.Any(u => u.UserName == "founder"))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = "founder" };

            //    manager.Create(user, "ChangeItAsap!");

            //    manager.AddToRole(user.Id, "AppAdmin");
            //}
        }

        /*
        INSERT INTO[dbo].[] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
        VALUES(N'4e4a3d13-77fc-4a5c-ae1d-0006d16db227', N'abc@def.com', 0, N'ANcGSMgDe7lebE80rkzW1e8aD/YfzA+XIntKiCFDsvZiB04WigXzkkFtpiY+zENN1Q==', N'fb53b867-51f5-47a7-81a1-9106f2d66430', NULL, 0, 0, NULL, 1, 0, N'abc@def.com')
        */

        public static void SeedProjects(IEJPApps.Models.Infrastructure.ApplicationDbContext context)
        {
            context.Projects.AddOrUpdate(
              p => p.ProjectNumber,
              new Project
              {
                  Id = new Guid("bc3998f1-1d8c-4be6-8e3f-04dcaaeb7209"),
                  ProjectNumber = "1388",
                  Customer = "4895 Hôtel-de-ville",
                  Description = "4895 hôtel - de - ville - remplacement 30 panneaux electriques"
              },
              new Project
              {
                  Id = new Guid("ed5108f5-d6ab-43ea-be2c-0b694559e28a"),
                  ProjectNumber = "5615",
                  Customer = "Comprod",
                  Description = "Comprod - ajout luminaires fluorescents"
              },
              new Project
              {
                  Id = new Guid("bf5a8cc5-7a6e-4f16-9c26-751f3073f04a"),
                  ProjectNumber = "5616",
                  Customer = "Philippe Peloquin",
                  Description = "Philippe peloquin - vérification chauffage"
              },
              new Project
              {
                  Id = new Guid("d3ed9505-4b0c-45b3-968b-2424903dc94d"),
                  ProjectNumber = "5618",
                  Customer = "Gaston Lagaffe",
                  Description = "Gaston Lagaffe"
              }
            );
        }
    }
}
