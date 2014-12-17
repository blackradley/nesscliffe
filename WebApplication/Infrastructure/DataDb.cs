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
        public DbSet<Month> Months { get; set; }
        public DbSet<MonthAttention> MonthAttentions { get; set; }
        //public DbSet<MonthArrive> MonthArrives { get; set; }

        IQueryable<Site> ISitesDataSource.Sites
        {
            get { return Sites; }
        }
        IQueryable<Month> ISitesDataSource.Months
        {
            get { return Months; }
        }
        IQueryable<MonthAttention> ISitesDataSource.MonthAttentions
        {
            get { return MonthAttentions; }
        }
        //IQueryable<MonthArrive> ISitesDataSource.MonthArrives
        //{
        //    get { return MonthArrives; }
        //}
    }
}