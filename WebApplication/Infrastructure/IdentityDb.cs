using System.Data.Entity;
using DataAccess;
using Microsoft.AspNet.Identity.EntityFramework;

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

        /// <summary>
        /// Nullable but Required.
        /// 
        /// Some of the fields are nullable but I want MVC to respond to them as if they were required.
        /// Simply putting [Required(ErrorMessage = "Please estimate marketing effort")] on the property
        /// makes the field in the database not nullable.  Setting the Property to IsOptional keeps
        /// the database nullable, whilst MVC still enforces that it is required.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ATTENTION
            modelBuilder.Entity<Month>().Property(m => m.MarketingEffort).IsOptional();
            // ARRIVING
            modelBuilder.Entity<Month>().Property(m => m.VisitorsGeneral).IsOptional();
            modelBuilder.Entity<Month>().Property(m => m.VisitorsMember).IsOptional();
            modelBuilder.Entity<Month>().Property(m => m.VisitorsSchool).IsOptional();
            modelBuilder.Entity<Month>().Property(m => m.IncomeAdmissions).IsOptional();
            // SHOPPING
            modelBuilder.Entity<Month>().Property(m => m.IsRetail).IsOptional();
            // REFRESHMENT
            modelBuilder.Entity<Month>().Property(m => m.IsCatering).IsOptional();
            // DONATION
            modelBuilder.Entity<Month>().Property(m => m.IsDonationOpportunity).IsOptional();
            // EXPERIENCE
            modelBuilder.Entity<Month>().Property(m => m.IsAdditionalEvents).IsOptional();
            // the all important base class call! 
            base.OnModelCreating(modelBuilder);
        }
    }
}