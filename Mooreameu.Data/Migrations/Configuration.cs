using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooreameu.Model;

namespace Mooreameu.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MooreameuDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Mooreameu.Data.MooreameuDbContext";
        }

        protected override void Seed(MooreameuDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var adminRole = new IdentityRole { Name = "UserAdministrator" };
                var userRole = new IdentityRole {Name = "SimpleUser"};

                manager.Create(adminRole);
                manager.Create(userRole);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@admin.bg"
                };

                var testUser = new User
                {
                    UserName = "test",
                    Email = "test@test.bg"
                };

                manager.Create(admin, "root");
                manager.AddToRole(admin.Id, "UserAdministrator");
                manager.Create(testUser, "test");
                manager.AddToRole(testUser.Id, "SimpleUser");
            }
        }
    }
}
