 using DataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
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
        public ActionResult Index([Bind(Prefix = "id")]Guid? siteId, String message)
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
            ViewBag.Message = message;
            return View(site);
        }

        // POST: Months/Create?SiteId=582e5585-0a86-417b-bee3-5c2af842747b&MonthTime=01%2F01%2F2015%2000%3A00%3A00
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiteId, MonthTime")] Guid siteId, DateTime monthTime)
        {
            var site = _dataDb.Sites.Find(siteId);
            var newMonth = new Month();
            var message = monthTime.ToString("MMM yyyy");

            // Confirm the user owns this site.
            if (User.Identity.GetUserId() != site.UserId)
            {
                return RedirectToAction("Index", "Sites", new { message = "Your IP has been logged." });
            }

            // Make sure this month hasn't already been created, if it is in this list just go to it.
            var monthsEitherSide = MonthsEitherSide(monthTime, site);
            var thisMonth = monthsEitherSide.Find(i => i.MonthTime == monthTime);
            if (thisMonth != null) // the month is already present.
            {
                return RedirectToAction("Edit", new { thisMonth.Id, message = message + " already present." });
            }

            // Copy the nearest month if there is one.
            var nearestMonth = NearestMonth(monthTime, monthsEitherSide);
            if (nearestMonth.Id != Guid.Empty)
            {
                newMonth = nearestMonth.ShallowCopy();
                message += " copied from " + nearestMonth.MonthTime.ToString("MMM yyyy");
            }
            else
            {
                message += " added";
            }

            // Set the new month values and save
            newMonth.SiteId = siteId;
            newMonth.Id = Guid.NewGuid();
            newMonth.MonthTime = monthTime;
            _dataDb.Months.Add(newMonth);
            _dataDb.Configuration.ValidateOnSaveEnabled = false;
            _dataDb.SaveChanges();

            return RedirectToAction("Edit", new { newMonth.Id, messge = message });
        }

        /// <summary>
        /// Find the month nearest to the given month.
        /// </summary>
        /// <param name="monthTime"></param>
        /// <param name="monthsEitherSide"></param>
        /// <returns></returns>
        private static Month NearestMonth(DateTime monthTime, IEnumerable<Month> monthsEitherSide)
        {
            var min = int.MaxValue; // Just a big number to start from
            var epoch = new DateTime(1970, 1, 1); // Begining of the Unix epoch, well you have to choose something.
            var newMonthDaysSinceEpoch = monthTime.Subtract(epoch).Days;
            var nearestMonth = new Month();
            foreach (Month oldMonth in monthsEitherSide)
            {
                var oldMonthDaysSinceEpoch = oldMonth.MonthTime.Subtract(epoch).Days;
                oldMonthDaysSinceEpoch += 15; // To favour the previous month.
                var daysBetweenOldAndNew = Math.Abs(newMonthDaysSinceEpoch - oldMonthDaysSinceEpoch);
                if (daysBetweenOldAndNew < min)
                {
                    min = daysBetweenOldAndNew;
                    nearestMonth = oldMonth;
                }
            }
            return nearestMonth;
        }

        /// <summary>
        /// Get the months either side of a given month.
        /// </summary>
        /// <param name="monthTime"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        private static List<Month> MonthsEitherSide(DateTime monthTime, Site site)
        {
            var earliest = monthTime.AddMonths(5);
            var latest = monthTime.AddMonths(-5);
            var months = site.Months
                .Where(m => m.MonthTime > latest)
                .Where(m => m.MonthTime < earliest)
                .Select(m => m)
                .ToList();
            return months;
        }

        //// GET: Months/Edit/117ca2a3-fb5a-4882-8e74-23cccf07db73
        public ActionResult Edit(Guid? id, String message)
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
                return RedirectToAction("Index", "Sites", new { message = "Your IP has been logged." });
            }
            ViewBag.Message = message;
            return View("Edit", siteAndMonthViewModel);
        }

        // POST: Months/Edit/117ca2a3-fb5a-4882-8e74-23cccf07db73
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Month month, String submit) // TODO: replace the [Bind(Include = "MarketingSpend")]
        {
            // We'll need a model to send back which includes the Site information
            var site = _dataDb.Sites.Find(month.SiteId);
            var siteAndMonthViewModel = new SiteAndMonthViewModel()
            {
                Site = site,
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
                if (submit == "Save")
                {
                    var message = month.MonthTime.ToString("MMM yyyy") + " has been saved.";
                    return RedirectToAction("Index", "Months", new { id = month.SiteId, message });
                    //return View("Index", site);
                }
                else
                {
                    ViewBag.Message = "This month has been updated.";
                    return View("Edit", siteAndMonthViewModel);  
                }
                
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
