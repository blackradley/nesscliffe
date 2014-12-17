using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DataAccess;
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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Month>().HasKey(pk => pk.Id).ToTable("Months");
        //    modelBuilder.Entity<MonthAttention>().HasKey(pk => pk.Id).ToTable("Months");
        //    modelBuilder.Entity<Month>()
        //        .HasRequired(e => e.MonthAttention)
        //        .WithRequiredPrincipal(c => c.Month);

        //    modelBuilder.Entity<MonthArrive>().HasKey(pk => pk.Id).ToTable("Months");
        //    modelBuilder.Entity<Month>()
        //        .HasRequired(e => e.MonthArrive)
        //        .WithRequiredPrincipal(c => c.Month);


        //}
    }
}