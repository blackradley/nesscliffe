using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccess;
using Microsoft.AspNet.Identity;

namespace WebApplication.Models
{
    public class DataViewModel
    {
        public bool HasPassword { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class SiteAndMonthViewModel
    {
        public Site Site { get; set; }
        public Month Month { get; set; }
    }

    /// <summary>
    /// Month d
    /// </summary>
    public class MonthDataViewModel
    {
        public DateTime MonthTime { get; set; }
        public int VisitorsTotal { get; set; }
        public double VisitorsTotalModel { get; set; }
        public double VisitorsTotalModelUpper { get; set; }
        public int? IncomeAdmissions { get; set; }
        public double IncomeAdmissionsModel { get; set; }
        public double IncomeAdmissionsModelUpper { get; set; }
        public double RetailIncomePerVisitor { get; set; }
        public double RetailIncomePerVisitorModel { get; set; }
        public double RetailIncomePerVisitorModelUpper { get; set; }
        public double RefreshmentIncomePerVisitor { get; set; }
        public double RefreshmentIncomePerVisitorModel { get; set; }
        public double RefreshmentIncomePerVisitorModelUpper { get; set; }
    }
}