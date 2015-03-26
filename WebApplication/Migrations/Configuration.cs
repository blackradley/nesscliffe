using DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication.Infrastructure;

namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication.Infrastructure.DataDb>
    {
        public Configuration()
        {
            // No Automatic Migrations.  The Migrations are handled by the scripts
            // in the Migrations directory and are run by the Global.asax if they 
            // are needed.
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(DataDb context)
        {
            // Add the test user so it is available for smoke tests.
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);
            var user = new ApplicationUser
            {
                UserName = "insightblackradley@mailinator.com", 
                Email = "insightblackradley@mailinator.com",
                LockoutEnabled = true
            };
            userManager.Create(user, "password");
        }
    }
}
