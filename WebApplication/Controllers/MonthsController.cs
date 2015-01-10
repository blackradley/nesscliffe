using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using WebApplication.Infrastructure;
using WebApplication.Models;

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

        // POST: Months/Create/Id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiteId, MonthTime")] Guid siteId, DateTime monthTime)
        {
            // TODO: check that the user is allowed to do this.
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

            //return View("Attention", attentionViewModel);
            return RedirectToAction("Attention", new { month.Id, message = "New month " + month.MonthTime.ToString("MMM yyyy") + " added." });
        }

        //// GET: Months/Attention/117ca2a3-fb5a-4882-8e74-23cccf07db73
        public ActionResult Attention(Guid id, string message)
        {
            var month = _dataDb.Months.Find(id);
            var monthAttention = month.MonthAttention;
            if (monthAttention == null) // it has not been previously saved
            {
                monthAttention = new MonthAttention();
                month.MonthAttention = monthAttention;

                var monthArrive = new MonthArrive();
                month.MonthArrive = monthArrive;
                _dataDb.Configuration.ValidateOnSaveEnabled = false;
                _dataDb.SaveChanges();
            }

            var attentionViewModel = new AttentionViewModel()
            {
                Site = month.Site,
                Month = month
            };

            //ViewBag.Message = message;
            return View("Attention", attentionViewModel);
        }

        // POST: Months/Attention/117ca2a3-fb5a-4882-8e74-23cccf07db73
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Attention(Guid id, MonthAttention monthAttention) // TODO: replace the [Bind(Include = "MarketingSpend")]
        {
            var month = _dataDb.Months.Find(id);
            var site = month.Site;
            var attentionViewModel = new AttentionViewModel()
            {
                Site = site,
                Month = month
            };

            if (ModelState.IsValid)
            {
                monthAttention.Id = id; // The Id needs to be set because it isn't part of the monthAttention
                _dataDb.Entry(monthAttention).State = EntityState.Modified;
                _dataDb.SaveChanges();
                attentionViewModel.MonthAttention = monthAttention;
                ViewBag.Message = "Attention has been updated.";
                return View("Attention", attentionViewModel);
            }
            // The model wasn't valid so show the view back to the user with the "duff" data.
            attentionViewModel.MonthAttention = monthAttention;
            ViewBag.Message = "The model is not valid.";
            return View("Attention", attentionViewModel);
        }

        public ActionResult Arrive(Guid id, string message)
        {
            // Create the view model for the attention category for the month in question.
            // TODO: Explain why I can't just navigate to the Site.  It seems that EF can't
            // because there are separate models on a one months table.
            var monthArrive = _dataDb.MonthArrives.Find(id);
            //var site = _dataDb.Sites.Find(monthArrive.SiteId);
            //var arriveViewModel = new ArriveViewModel()
            //{
            //    Site = site,
            //    Month = monthArrive,
            //    MonthArrive = monthArrive
            //};
            ViewBag.Message = message;
            //return View("Arrive", arriveViewModel);
            return View("Arrive");
            
        }
        public ActionResult Shop(Guid? id, string message) { return this.GetView(id, message); }

        private ActionResult GetView(Guid? id, string message)
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



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Arrive(MonthArrive month) // TODO: replace the [Bind(Include = "HoursMonday")]
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _dataDb.Entry(month).State = EntityState.Unchanged;
        //        _dataDb.Entry(month).Property(e => e.HoursMonday).IsModified = true;
        //        _dataDb.Entry(month).Property(e => e.HoursTuesday).IsModified = true;
        //        _dataDb.SaveChanges();
        //        return RedirectToAction("Arrive", new { id = month.Id, message = "Updated." });
        //    }
        //    return View(month);
        //}


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
