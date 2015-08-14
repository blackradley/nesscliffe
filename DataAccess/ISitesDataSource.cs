using System.Linq;

namespace DataAccess
{
    public interface ISitesDataSource
    {
        IQueryable<Site> Sites { get; }
        IQueryable<SiteCircumstance> SiteCircumstances { get; }
        IQueryable<Month> Months { get; }
    }
}