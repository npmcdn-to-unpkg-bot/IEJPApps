namespace IEJPApps.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    //internal sealed class Configuration : DbMigrationsConfiguration<IEJPApps.Models.Infrastructure.ApplicationDbContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = false; // true;
    //    }

    //    protected override void Seed(IEJPApps.Models.Infrastructure.ApplicationDbContext context)
    //    {
    //        context.Projects.AddOrUpdate(
    //            new Models.Project
    //            {
    //                Id = new Guid("bc3998f1-1d8c-4be6-8e3f-04dcaaeb7209"),
    //                Active = false,
    //                ProjectNumber = "1388",
    //                Customer = "4895 Hôtel-de-ville",
    //                Description = "Remplacement 30 panneaux electriques",
    //                Created = new DateTime(2016, 02, 01),
    //                Started = new DateTime(2016, 02, 03),
    //                Completed = null,
    //                Updated = DateTime.Now
    //            },
    //            new Models.Project
    //            {
    //                Id = new Guid("ed5108f5-d6ab-43ea-be2c-0b694559e28a"),
    //                Active = false,
    //                ProjectNumber = "5615",
    //                Customer = "Comprod",
    //                Description = "Ajout luminaires fluorescents",
    //                Created = new DateTime(2016, 02, 01),
    //                Started = new DateTime(2016, 02, 01),
    //                Completed = null,
    //                Updated = DateTime.Now
    //            },
    //            new Models.Project
    //            {
    //                Id = new Guid("d3ed9505-4b0c-45b3-968b-2424903dc94d"),
    //                Active = true,
    //                ProjectNumber = "5618",
    //                Customer = "Gaston Lagaffe",
    //                Description = "Soumission",
    //                Created = new DateTime(2016, 02, 21),
    //                Started = new DateTime(2016, 02, 28),
    //                Completed = null,
    //                Updated = new DateTime(2016, 03, 15)
    //            },
    //            new Models.Project
    //            {
    //                Id = new Guid("bf5a8cc5-7a6e-4f16-9c26-751f3073f04a"),
    //                Active = true,
    //                ProjectNumber = "5616",
    //                Customer = "Philippe Peloquin",
    //                Description = "Vérification chauffage",
    //                Created = new DateTime(2016, 03, 19),
    //                Started = new DateTime(2016, 03, 25),
    //                Completed = null,
    //                Updated = DateTime.Now
    //            },
    //            new Models.Project
    //            {
    //                Id = new Guid("41d7aa9c-9497-43e0-89a7-ec5edc28f7e8"),
    //                Active = true,
    //                ProjectNumber = "1234",
    //                Customer = "Stephane",
    //                Description = "Test creation projet",
    //                Created = DateTime.Now,
    //                Started = new DateTime(2016, 02, 03),
    //                Completed = null,
    //                Updated = DateTime.Now
    //            }
    //        );

    //        context.Employees.AddOrUpdate(
    //            new Models.Employee
    //            {
    //                Id = new Guid("6e44a8af-8f39-4f15-a665-19e0c3ac75b9"),
    //                Active = true,
    //                Number = "123456",
    //                FirstName = "Stéphane",
    //                LastName = "Pilote",
    //                Rate = new decimal(120.77),
    //                Mobile = "123-456-7890",
    //                Email = "abc@def.com"
    //            },
    //            new Models.Employee
    //            {
    //                Id = new Guid("d7d32f00-2235-4fab-b389-35f86e9e8ef0"),
    //                Active = true,
    //                Number = "888",
    //                FirstName = "Titi",
    //                LastName = "Tutu",
    //                Rate = new decimal(34.90),
    //                Mobile = "8678767865",
    //                Email = "test@acme.com"
    //            },
    //            new Models.Employee
    //            {
    //                Id = new Guid("45222410-b791-45d3-9bf9-5ef63a4a579e"),
    //                Active = false,
    //                Number = "1234",
    //                FirstName = "Geneviève",
    //                LastName = "Provost",
    //                Rate = new decimal(4.75),
    //                Mobile = "111-222-3333",
    //                Email = ""
    //            },
    //            new Models.Employee
    //            {
    //                Id = new Guid("7cac39da-6da9-4f3b-ba0c-cb9c42188c8c"),
    //                Active = true,
    //                Number = "34567",
    //                FirstName = "Jean-François",
    //                LastName = "Provost",
    //                Rate = new decimal(200),
    //                Mobile = "890-543-7896",
    //                Email = "jfprovost@iejp.com"
    //            }
    //        );
    //    }
    //}
}
