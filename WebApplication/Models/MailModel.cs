using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class MailModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string From { get; set; }
        public string Destination { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Template { get; set; }
    }
}