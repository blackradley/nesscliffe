using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Microsoft.AspNet.Identity;

namespace WebApplication.Controllers
{
    public abstract  class BaseController : Controller
    {
        /// <summary>
        /// Does the user own this site and is therefore allowed
        /// to do stuff to it.
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        protected Boolean UserNotAllowed(Site site)
        {
            var siteUserId = site.UserId;
            var userId = User.Identity.GetUserId();
            return siteUserId != userId;
        }

    }
}