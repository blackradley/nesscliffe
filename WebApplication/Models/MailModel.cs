using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using SendGrid;
using WebApplication.Infrastructure;

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

    public static class MailAdmin
    {
        public static void Send(string title, string message)
        {
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.AddTo(Email.AdministratorAddress); // send to us.
            sendGridMessage.From = new MailAddress(Email.AdministratorAddress, Email.AdministratorName);
            sendGridMessage.Subject = "Insight: " + title;
            sendGridMessage.Text = message;
            sendGridMessage.Html = message;
            // Create network credentials to access your SendGrid account
            var credentials = new NetworkCredential(Email.Username, Email.Password);
            // Create an Web transport for sending email.
            var transportWeb = new Web(credentials);
            transportWeb.Deliver(sendGridMessage);
        }
    }
}