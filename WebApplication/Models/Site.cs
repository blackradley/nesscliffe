using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication.Models
{

    [Table("Sites")]
    public class Site
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PerformanceDataSet> Months { get; set; }

    }

    [Table("PerformanceDataSets")]
    public class PerformanceDataSet
    {
        public Guid Id { get; set; }
        [ForeignKey("Site")]
        public Guid SiteId { get; set; }
        public DateTime Month { get; set; }
        public string WebsiteUrl { get; set; }
    }

    public partial class SiteContext : DbContext
    {
        public SiteContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Site> Sites { get; set; }
        public DbSet<PerformanceDataSet> PerformanceDataSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
