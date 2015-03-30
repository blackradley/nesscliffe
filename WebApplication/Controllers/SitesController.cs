using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Microsoft.AspNet.Identity;
using WebApplication.Helpers;
using WebApplication.Infrastructure;
using WebGrease;

namespace WebApplication.Controllers
{
    [Authorize]
    public class SitesController : BaseController
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


        //TODO: This is identical to Sites/Report/c4868028-d113-42ef-af6a-3ac2b00742fc. Merge them?
        public ActionResult Edit(Guid? id)
        {
            if (id == null) throw new HttpException(404, "Not found");
            Site site = _dataDb.Sites.Find(id);
            if (site == null) throw new HttpException(404, "Not found");
            if (UserNotAllowed(site)) throw new HttpException(404, "Not found");
            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Site site) // TODO: Replace the [Bind(Include = "Id,Name,....
        {
            if (UserNotAllowed(site)) throw new HttpException(404, "Not found");
            if (ModelState.IsValid)
            {
                _dataDb.Entry(site).State = EntityState.Modified;
                // The UserId is unmodified, the rest of the stuff comes from the form.
                _dataDb.Entry(site).Property(e => e.UserId).IsModified = false;
                // Capitalize the name of the site and the postcode
                var textInfo = new CultureInfo("en-GB").TextInfo;
                site.Name = textInfo.ToTitleCase(site.Name);
                site.Postcode = textInfo.ToUpper(site.Postcode);
                _dataDb.SaveChanges();
                return RedirectToAction("Index", "Sites", new { message = site.Name + " updated." });
            }
            return View(site);
        }

        //TODO: This is identical to Sites/Edit/c4868028-d113-42ef-af6a-3ac2b00742fc. Merge them?
        public ActionResult Report(Guid? id)
        {
            if (id == null) throw new HttpException(404, "Not found");
            Site site = _dataDb.Sites.Find(id);
            if (site == null) throw new HttpException(404, "Not found");
            if (UserNotAllowed(site)) throw new HttpException(404, "Not found");
            return View(site);
        }

        // GET: Sites/Delete/c4868028-d113-42ef-af6a-3ac2b00742fc
        public ActionResult Delete(Guid? id)
        {
            if (id == null) throw new HttpException(404, "Not found");
            Site site = _dataDb.Sites.Find(id);
            if (site == null) throw new HttpException(404, "Not found");
            if (UserNotAllowed(site)) throw new HttpException(404, "Not found");
            return View(site);
        }

        // POST: Sites/Delete/c4868028-d113-42ef-af6a-3ac2b00742fc
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Site site = _dataDb.Sites.Find(id);
            if (UserNotAllowed(site)) throw new HttpException(404, "Not found");
            _dataDb.Sites.Remove(site);
            _dataDb.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult ReportData(Guid? id)
        {
            Site site = _dataDb.Sites.Find(id);
            if (UserNotAllowed(site)) throw new HttpException(404, "Not found");
            var months = site.Months.OrderBy(c => c.MonthTime).ToList();
            site.Months = months;
            return Json(site, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataDb.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// The built in Json serializer cannot handle circular references so override
        /// it with the Newtonsoft.Json one.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <param name="contentEncoding"></param>
        /// <param name="behavior"></param>
        /// <returns></returns>
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}
