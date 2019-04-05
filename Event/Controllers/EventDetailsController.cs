using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Event.Models;

namespace Event.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EventDetailsController : Controller
    {
        IMockEventDetails db;

       // private DbModel db = new DbModel();
       //constructor
       public EventDetailsController()
        {
            this.db = new IDataEventDetails();
        }

        public EventDetailsController(IDataEventDetails mockDb)
        {
            this.db = mockDb;
        }

        [AllowAnonymous]
        // GET: EventDetails
        public ActionResult Index()
        {
            return View(db.EventDetails.ToList());
        }

        // GET: EventDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EventDetail eventDetail = db.EventDetails.Find(id);
            EventDetail eventDetail = db.EventDetails.SingleOrDefault( e => e.IdNumber == id);
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            return View(eventDetail);
        }

        // GET: EventDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNumber,Name,Starts,Ends")] EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                //db.EventDetails.Add(eventDetail);
                //db.SaveChanges();
                db.Save(eventDetail);
                return RedirectToAction("Index");
            }

            return View(eventDetail);
        }

        // GET: EventDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EventDetail eventDetail = db.EventDetails.Find(id);
            EventDetail eventDetail = db.EventDetails.SingleOrDefault(e => e.IdNumber == id);
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            return View(eventDetail);
        }

        // POST: EventDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNumber,Name,Starts,Ends")] EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                //db.EventDetails.Add(eventDetail);
                //db.SaveChanges();
                db.Save(eventDetail);
                return RedirectToAction("Index");
            }
            return View(eventDetail);
        }

        // GET: EventDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EventDetail eventDetail = db.EventDetails.Find(id);
            EventDetail eventDetail = db.EventDetails.SingleOrDefault(e => e.IdNumber == id);
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            return View(eventDetail);
        }

        // POST: EventDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //EventDetail eventDetail = db.EventDetails.Find(id);
            EventDetail eventDetail = db.EventDetails.SingleOrDefault(e => e.IdNumber == id);
            //db.EventDetails.Add(eventDetail);
            //db.SaveChanges();
            db.Delete(eventDetail);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    } 
}
