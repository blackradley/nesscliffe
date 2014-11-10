using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using SendGrid;
using WebApplication.Models;

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
                // Create the email object first, then add the properties.
                var sendGridMessage = new SendGridMessage();
                sendGridMessage.AddTo(modelMail.From); // send to them.
                sendGridMessage.AddTo(Email.AdministratorAddress); // send to us.
                sendGridMessage.From = new MailAddress(Email.AdministratorAddress, Email.AdministratorName);
                sendGridMessage.Subject = "Invitation Request";
                sendGridMessage.Text = modelMail.From;
                sendGridMessage.Html = modelMail.From;
                sendGridMessage.EnableTemplateEngine(Email.ConfirmInvitationTemplate);

                // Create network credentials to access your SendGrid account
                var credentials = new NetworkCredential(Email.Username, Email.Password);
                // Create an Web transport for sending email.
                var transportWeb = new Web(credentials); 
                transportWeb.Deliver(sendGridMessage);
                return View("RequestThanks", modelMail);
            }
            else
            {
                return View();
            }
        }
	}
}