using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Microsoft.AspNet.Identity;
using WebApplication.Infrastructure;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class MonthsController : Controller
    {
        private readonly DataDb _dataDb = new DataDb();

        // GET: Months
        // TODO: restrict access to owner of this site
        public ActionResult Index([Bind(Prefix = "id")]Guid? siteId)
        {
            if (siteId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site = _dataDb.Sites.Find(siteId);

            // How many dates are available.
            var now = DateTime.Now;
            const int monthsBetween = 12;
            var then = now.AddMonths(monthsBetween * (-1));
            var possibleDates = Enumerable.Range(0, monthsBetween)
                .Select(m => new DateTime(then.Year, then.Month, 1).AddMonths(m)).Reverse();
            var usedDates = from monthList in site.Months select monthList.MonthTime;
            var availableDates = possibleDates.Where(o => !usedDates.Contains(DateTime.Parse(o.ToLongDateString())))
                .Select(d => d.ToString("MMM yyyy")).ToList();


            // Add unused months to the months collection
            foreach (var dateTime in availableDates)
            {
                var month = new Month
                {
                    MonthTime = Convert.ToDateTime(dateTime)
                };
                site.Months.Add(month);
                site.Months = site.Months.OrderByDescending(i => i.MonthTime).ToList();
            }
   
            if (site == null)
            {
                return HttpNotFound();
            }
            return View(site);
        }

        // POST: Months/Create?SiteId=582e5585-0a86-417b-bee3-5c2af842747b&MonthTime=01%2F01%2F2015%2000%3A00%3A00
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiteId, MonthTime")] Guid siteId, DateTime monthTime)
        {
            // TODO: check that the user is allowed to do this.
            // then create a new month.
            var month = new Month()
            {
                SiteId = siteId,
                Id = Guid.NewGuid(),
                MonthTime = monthTime
            };
            // Do not check if the model is valid because it certainly isn't at this point.
            _dataDb.Months.Add(month);
            _dataDb.Configuration.ValidateOnSaveEnabled = false;
            _dataDb.SaveChanges();

            // TODO: find out why below doesn't work, it would be nice to merge these two methods.
            //var site = _dataDb.Sites.Find(siteId);
            //var siteAndMonthViewModel = new SiteAndMonthViewModel()
            //{
            //    Site = site,
            //    Month = month
            //};
            //return View("Edit", siteAndMonthViewModel);
            return RedirectToAction("Edit", new { month.Id, message = "A new month (" + month.MonthTime.ToString("MMM yyyy") + ") has been added." });
        }

        //// GET: Months/Edit/117ca2a3-fb5a-4882-8e74-23cccf07db73
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue) return RedirectToAction("Index", "Home");// Catch null ids.
            var month = _dataDb.Months.Find(id);
            var siteAndMonthViewModel = new SiteAndMonthViewModel()
            {
                Site = month.Site,
                Month = month
            };
            // Confirm the user owns this month.
            if (User.Identity.GetUserId() != siteAndMonthViewModel.Site.UserId)
            {
                return RedirectToAction("Index", "Sites", new { message = "Your IP and behaviour has been logged." });
            }
            return View("Edit", siteAndMonthViewModel);
        }

        // POST: Months/Edit/117ca2a3-fb5a-4882-8e74-23cccf07db73
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Month month) // TODO: replace the [Bind(Include = "MarketingSpend")]
        {
            // We'll need a model to send back which includes the Site information
            var siteAndMonthViewModel = new SiteAndMonthViewModel()
            {
                Site = _dataDb.Sites.Find(month.SiteId),
                Month = month
            };
            if (ModelState.IsValid)
            {
                _dataDb.Months.Attach(month);
                var entry = _dataDb.Entry(month);
                entry.State = EntityState.Modified;
                // The SiteId and MonthTime are in hidden field and should not be changed so...
                entry.Property(e => e.SiteId).IsModified = false;
                entry.Property(e => e.MonthTime).IsModified = false;
                _dataDb.SaveChanges();
                ViewBag.Message = "This month (" + month.MonthTime.ToString("MMM yyyy") + ") has been updated.";
                return View("Edit", siteAndMonthViewModel);
            }
            //// The model wasn't valid so show the view back to the user with the "duff" data.
            ViewBag.Message = "Please check your entries.";
            return View("Edit", siteAndMonthViewModel);
        }

        // GET: Months/Delete/1ddf361e-29c4-43d4-9d7f-f4656520789e
        public ActionResult Delete(Guid id)
        {
            Month month = _dataDb.Months.Find(id);
            if (month == null)
            {
                return HttpNotFound();
            }
            var siteAndMonthViewModel = new SiteAndMonthViewModel()
            {
                Site = month.Site,
                Month = month
            };
            return View(siteAndMonthViewModel);
        }

        // POST: Months/Delete/1ddf361e-29c4-43d4-9d7f-f4656520789e
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var month = _dataDb.Months.Find(id);
            _dataDb.Months.Remove(month);
            _dataDb.SaveChanges();
            return RedirectToAction("Index", "Months", new { id = month.SiteId});
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
