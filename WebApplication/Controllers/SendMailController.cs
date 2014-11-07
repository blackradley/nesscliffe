using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using SendGrid;

namespace WebApplication.Controllers
{
    public class SendMailController : Controller
    {
        //
        // GET: /SendMail/RequestInvite
        public ActionResult RequestInvite()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RequestInvite(Models.MailModel modelMail)
        {
            if (ModelState.IsValid)
            {
                String administratorEmail = System.Environment.GetEnvironmentVariable("SENDGRID_DEST");
                // Create the email object first, then add the properties.
                var myMessage = new SendGridMessage();
                myMessage.AddTo(modelMail.From);
                myMessage.AddTo(administratorEmail);
                myMessage.From = new MailAddress(administratorEmail, "Insight Website");
                myMessage.Subject = "Invitation Request";
                myMessage.Html = modelMail.From;
                myMessage.EnableTemplateEngine("5ad29324-e439-46ff-b3c6-64d214462920");

                // Create network credentials to access your SendGrid account
                String username = System.Environment.GetEnvironmentVariable("SENDGRID_USER");
                String password = System.Environment.GetEnvironmentVariable("SENDGRID_PASS");
                // Create credentials, specifying your user name and password.
                var credentials = new NetworkCredential(username, password);
                // Create an Web transport for sending email.
                var transportWeb = new Web(credentials); 
                transportWeb.Deliver(myMessage);
                return View("RequestThanks", modelMail);
            }
            else
            {
                return View();
            }
        }
	}
}