using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public static class Email
    {
        static Email()
        {
            AdministratorAddress = Environment.GetEnvironmentVariable("SENDGRID_DEST");
            Username = System.Environment.GetEnvironmentVariable("SENDGRID_USER");
            Password = System.Environment.GetEnvironmentVariable("SENDGRID_PASS");
        }
        public static string AdministratorAddress;
        public static string Username;
        public static string Password;
        public const string ConfirmInvitationTemplate = "5ad29324-e439-46ff-b3c6-64d214462920";
    }
}