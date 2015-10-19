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
                var userRole = new IdentityRole { Name = "SimpleUser" };

                manager.Create(adminRole);
                manager.Create(userRole);

                if (!context.Users.Any(u => u.UserName == "admin"))
                {
                    AddAdministratorRoleWithUser(context);
                }

                if (!context.Contests.Any())
                {
                    AddContests(context);
                }
            }
        }


        private void AddAdministratorRoleWithUser(MooreameuDbContext context)
        {
            var admin = new User
            {
                Email = "admin@admin.com",
                UserName = "admin"
            };

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 2,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            var password = admin.UserName;
            var userCreateResult = userManager.Create(admin, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
            context.SaveChanges();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole("Administrator"));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            // Add "admin" user to "Administrator" role
            var adminUser = context.Users.First(user => user.UserName == "admin");
            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, "Administrator");
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private void AddContests(MooreameuDbContext context)
        {
            var user = context.Users.FirstOrDefault();
            var deadLine = DateTime.Now;
            var FirstContest = new Contest 
            {
                CreatedOn = DateTime.Now,
                DeadLine = DeadlineStrategy.CountParticipants,
                Description  = "Prettiest dog wins!!",
                Owner = user,
                Status = ContestStatus.Opened,
                Title = "Dog contest",
                 Voting = VotingStrategy.Open
            };

            var SecondContest = new Contest
            {
                CreatedOn = DateTime.Now,
                DeadLine = DeadlineStrategy.CountParticipants,
                Description = "let`s see which car is most liked",
                Owner = user,
                Status = ContestStatus.Opened,
                Title = "Car battle",
                Voting = VotingStrategy.Open
            };


            var ThirdContest = new Contest
            {
                CreatedOn = DateTime.Now,
                DeadLine = DeadlineStrategy.CountParticipants,
                Description = "The cutest pussy wins(it`s about kitties you pervert)",
                Owner = user,
                Status = ContestStatus.Opened,
                Title = "Pussy contest",
                Voting = VotingStrategy.Open
            };
            
               var FourthContest = new Contest
            {
                CreatedOn = DateTime.Now,
                DeadLine = DeadlineStrategy.CountParticipants,
                Description = "Which beer does the bulgarian drinks most",
                Owner = user,
                Status = ContestStatus.Opened,
                Title = "Beers",
                Voting = VotingStrategy.Open
            };


            context.Contests.Add(FirstContest);
            context.Contests.Add(SecondContest);
            context.Contests.Add(ThirdContest);
            context.Contests.Add(FourthContest);
            context.SaveChanges();
        }
    }
}
