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

    public class SiteAndMonthViewModel
    {
        public Site Site { get; set; }
        public Month Month { get; set; }
        
    }

}