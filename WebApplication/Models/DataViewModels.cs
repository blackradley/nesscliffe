using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

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

    /// <summary>
    /// Subclass!  Why?
    /// 
    /// You are looking at this, thinking why on earth does the view model subclass the Month?
    /// There appears to be no need for it.  That is true except the Validation Messages were
    /// inaccessible in the Site.  So this will not work in the parent of the partial class.
    /// 
    ///     @Html.ValidationMessageFor(model => model.Month.MarketingEffort, "!")
    ///  
    /// If the Site subclasses the month they become available like this.
    /// 
    ///     @Html.ValidationMessageFor(model => model.MarketingEffort, "!")
    /// 
    /// Personally I think it is messy but I couldn't think of another way of getting to them.
    /// </summary>
    public class SiteAndMonthViewModel : Month
    {
        public new Site Site { get; set; }
        public Month Month { get; set; }
    }

}