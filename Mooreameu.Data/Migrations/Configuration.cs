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

               FourthContest.Pictures.Add(new Picture() 
               {
                   Status = PictureStatus.Ok,
                   SubmittedOn = DateTime.Now,
                   Name = "Some_Beeer",
                   Description = "biri4kaaa",
                   Contest = FourthContest,
                   Path = "http://www.carlsbergbulgaria.bg/SiteCollectionImages/PirinskoPackshot.png"
               });

               FourthContest.Pictures.Add(new Picture()
               {
                   Status = PictureStatus.Ok,
                   SubmittedOn = DateTime.Now,
                   Name = "Some_Beeer",
                   Description = "biri4kaaa",
                   Contest = FourthContest,
                   Path = "http://www.gigadrinks.com/userfiles/productimages/product_732.jpg"
               });

               FourthContest.Pictures.Add(new Picture()
               {
                   Contest = FourthContest,
                   Status = PictureStatus.Ok,
                   SubmittedOn = DateTime.Now,
                   Name = "Some_Beeer",
                   Description = "biri4kaaa",
                   Path = "http://shop24.bg/1794-thickbox/bira-ariana-svetlo-1l.jpg"
               });


               FourthContest.Pictures.Add(new Picture()
               {
                   Status = PictureStatus.Ok,
                   SubmittedOn = DateTime.Now,
                   Name = "Some_Beeer",
                   Description = "biri4kaaa",
                   Contest = FourthContest,
                   Path = "data:image/jpeg;base64,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"
               });


               FourthContest.Pictures.Add(new Picture()
               {
                   Status = PictureStatus.Ok,
                   SubmittedOn = DateTime.Now,
                   Name = "Some_Beeer",
                   Description = "biri4kaaa",
                   Contest = FourthContest,
                   Path = "http://econ.bg/content/Zagorka_new_bottleNEW(2).jpg"
               });


               FourthContest.Pictures.Add(new Picture()
               {
                   Status = PictureStatus.Ok,
                   SubmittedOn = DateTime.Now,
                   Name = "Some_Beeer",
                   Description = "biri4kaaa",
                   Contest = FourthContest,
                   Path = "http://krustnikut.bg/wp-content/uploads/2014/04/astikaken-372x372.jpg"
               });

               FourthContest.Pictures.Add(new Picture()
               {
                   Status = PictureStatus.Ok,
                   SubmittedOn = DateTime.Now,
                   Name = "Some_Beeer",
                   Description = "biri4kaaa",
                   Contest = FourthContest,
                   Path = "data:image/jpeg;base64,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"
               });

            context.Contests.Add(FirstContest);
            context.Contests.Add(SecondContest);
            context.Contests.Add(ThirdContest);
            context.Contests.Add(FourthContest);
            context.SaveChanges();
        }
    }
}
