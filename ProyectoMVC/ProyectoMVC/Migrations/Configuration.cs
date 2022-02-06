namespace ProyectoMVC.Migrations
{
    using Microsoft.AspNet.Identity;
    using ProyectoMVC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProyectoMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProyectoMVC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var passwordHash = new PasswordHasher();  //una clase proporcionada por identity 
            string password = passwordHash.HashPassword("Ss123*");
            context.Users.AddOrUpdate(u => u.UserName, //se inserta el nombre dle usuario con AddOrUpdate
            new ApplicationUser
            {
                UserName = "admin@rol.com",
                PasswordHash = password,
                SecurityStamp = Guid.NewGuid().ToString()  // Se compleat el campo de SecurityStamp para que al incluir el usuario o clave permita el acceso. 
            });
        }
    }
}
