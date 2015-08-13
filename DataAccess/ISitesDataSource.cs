using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISitesDataSource
    {
        IQueryable<Site> Sites { get; }
        IQueryable<SiteCircumstance> SiteCircumstances { get; }
        IQueryable<Month> Months { get; }
    }
}
