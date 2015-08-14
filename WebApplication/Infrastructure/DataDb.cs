using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DataAccess;

namespace WebApplication.Infrastructure
{
    public class DataDb : IdentityDb, ISitesDataSource
    {

        public DbSet<Site> Sites { get; set; }
        public DbSet<SiteCircumstance> SiteCircumstances { get; set; }
        public DbSet<Month> Months { get; set; }

        IQueryable<Site> ISitesDataSource.Sites
        {
            get { return Sites; }
        }

        IQueryable<SiteCircumstance> ISitesDataSource.SiteCircumstances
        {
            get { return SiteCircumstances; }
        }

        IQueryable<Month> ISitesDataSource.Months
        {
            get { return Months; }
        }
    }
}