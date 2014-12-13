using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using Glimpse.Mvc.Message;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using WebApplication.Infrastructure;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class SitesController : Controller
    {
        private readonly DataDb _dataDb = new DataDb();

        // GET: Sites for the user
        public ActionResult Index(string message)
        {
            IEnumerable<Site> sitesList = _dataDb.Sites.ToList().Where(site => site.UserId == User.Identity.GetUserId());
            ViewBag.Message = message;
            return View(sitesList);
        }

        // GET: Sites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Site site) // TODO: replace the [Bind(Include = "Id,UserId,...
        {
            if (ModelState.IsValid)
            {
                site.Id = Guid.NewGuid();
                site.UserId = User.Identity.GetUserId();
                _dataDb.Sites.Add(site);
                _dataDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(site);
        }

        // GET: Sites/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site = _dataDb.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            if (site.UserId != User.Identity.GetUserId())
            {
                return HttpNotFound();
            }
            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Site site) // TODO: Replace the [Bind(Include = "Id,Name,....
        {
            if (ModelState.IsValid)
            {
                _dataDb.Entry(site).State = EntityState.Modified;
                // The UserId is unmodified, the rest of the stuff comes from the form.
                _dataDb.Entry(site).Property(e => e.UserId).IsModified = false;
                // Capitalize the name of the site
                var textInfo = new CultureInfo("en-GB").TextInfo;
                site.Name = textInfo.ToTitleCase(site.Name);
                _dataDb.SaveChanges();
                //ViewBag.Message = site.Name + " has been updated.";
                //empData["Message"] = site.Name + " has been updated.";
                return RedirectToAction("Index", "Sites", new { message = site.Name + " has been updated." });
            }
            return View(site);
        }

        // GET: Sites/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site = _dataDb.Sites.Find(id);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Site site = _dataDb.Sites.Find(id);
            _dataDb.Sites.Remove(site);
            _dataDb.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
