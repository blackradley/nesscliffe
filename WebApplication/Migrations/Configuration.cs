using System;
using System.IO;
using System.Reflection;
using System.Text;
using CsvHelper;
using DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication.Infrastructure;

namespace WebApplication.Migrations
{
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

            // Copy in the circumstance data
            var assembly = Assembly.GetExecutingAssembly();
            const string resourceName = "WebApplication.Migrations.SeedData.SiteCircumstances.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;

                    var siteCircumstances = csvReader.GetRecords<SiteCircumstance>().ToArray();

                    foreach (SiteCircumstance siteCircumstance in siteCircumstances)
                    {
                        Site site = context.Sites.Find(siteCircumstance.SiteId);
                        // You can only enter data for sites that are already there so...
                        if (site != null)
                        {
                            siteCircumstance.Site = site;
                            context.SiteCircumstances.AddOrUpdate(siteCircumstance);
                        }
                    }
                    context.SaveChanges();
                }
            }
            
        }

    }
}
