using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Models
{
    public class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {

        protected override void Seed(SiteContext context)
        {
            var sites = new List<Site>
            {
                new Site {Name = "turkey"}
            };
            context.SaveChanges();
        }
    }
}
