using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ClassLibrary;

namespace WebApplication.Models
{
    public class DataContext : DbContext, ISitesDataSource
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        public DbSet<Site> Sites { get; set; }
        public DbSet<Month> Months { get; set; }

        IQueryable<Month> ISitesDataSource.Months
        {
            get { return Months; }
        }

        IQueryable<Site> ISitesDataSource.Sites
        {
            get { return Sites; }
        }
    }
}