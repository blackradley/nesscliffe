using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Helpers
{
    public class RemainingMonths
    {
        static IEnumerable<DateTime> Months(DateTime d0)
        {
            DateTime d1 = d0.AddYears(1);
            return Enumerable.Range(0, (d1.Year - d0.Year) * 12 + (d1.Month - d0.Month + 1))
                             .Select(m => new DateTime(d0.Year, d0.Month, 1).AddMonths(m));
        }
    }
}