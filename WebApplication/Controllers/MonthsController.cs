using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using WebApplication.Infrastructure;

namespace WebApplication.Controllers
{
    public class MonthsController : Controller
    {
        private readonly DataDb _dataDb = new DataDb();

        // GET: Months
        public ActionResult Index([Bind(Prefix = "id")]Guid? siteId)
        {
            if (siteId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site = _dataDb.Sites.Find(siteId);
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        // GET: Months/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Month month = _dataDb.Months.Find(id);
            if (month == null)
            {
                return HttpNotFound();
            }
            return View(month);
        }

        // GET: Months/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Months/Create/Id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, MonthTime")] Guid id, Month month)
        {
            // TODO: check that the user is allowed to do this.
            if (ModelState.IsValid)
            {
                month.Id = Guid.NewGuid();
                month.SiteId = id;
                _dataDb.Months.Add(month);
                _dataDb.SaveChanges();
                return RedirectToAction("Edit", new { Id = month.Id });

                
            }

            return View(month);
        }

        // GET: Months/Edit/5
        public ActionResult Edit(Guid? id, string message)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Month month = _dataDb.Months.Find(id);
            if (month == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = message;
            return View(month);
        }

        // POST: Months/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Month month) // TODO: replace the [Bind(Include = "
        {
            if (ModelState.IsValid)
            {
                _dataDb.Entry(month).State = EntityState.Modified;
                _dataDb.Entry(month).Property(e => e.MonthTime).IsModified = false;
                _dataDb.Entry(month).Property(e => e.SiteId).IsModified = false;
                _dataDb.SaveChanges();
                return RedirectToAction("Edit", "Months", new { id = month.Id, message = "Attention has been updated." });
            }
            return View(month);
        }

        // GET: Months/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Month month = _dataDb.Months.Find(id);
            if (month == null)
            {
                return HttpNotFound();
            }
            return View(month);
        }

        // POST: Months/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Month month = _dataDb.Months.Find(id);
            _dataDb.Months.Remove(month);
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
