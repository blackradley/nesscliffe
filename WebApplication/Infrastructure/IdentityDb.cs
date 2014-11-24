using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication.Models;

namespace WebApplication.Infrastructure
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static IdentityDb Create()
        {
            return new IdentityDb();
        }
    }
}