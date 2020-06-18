using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HealthCareStartup.Models;

namespace HealthCareStartup.Controllers
{
    public class OnlineOrdersController : Controller
    {
        private OEL2Entities db = new OEL2Entities();

        // GET: OnlineOrders
        public ActionResult Index()
        {
            var onlineOrders = db.OnlineOrders.Include(o => o.Diagnosi).Include(o => o.Medicine);
            return View(onlineOrders.ToList());
        }

        // GET: OnlineOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnlineOrder onlineOrder = db.OnlineOrders.Find(id);
            if (onlineOrder == null)
            {
                return HttpNotFound();
            }
            return View(onlineOrder);
        }

        // GET: OnlineOrders/Create
        public ActionResult Create()
        {
            ViewBag.DiagID = new SelectList(db.Diagnosis, "DiagID", "Details");
            ViewBag.MedID = new SelectList(db.Medicines, "MedID", "MedName");
            return View();
        }

        // POST: OnlineOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,MedID,DiagID,Quantity")] OnlineOrder onlineOrder)
        {
            if (ModelState.IsValid)
            {
                db.OnlineOrders.Add(onlineOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiagID = new SelectList(db.Diagnosis, "DiagID", "Details", onlineOrder.DiagID);
            ViewBag.MedID = new SelectList(db.Medicines, "MedID", "MedName", onlineOrder.MedID);
            return View(onlineOrder);
        }

        // GET: OnlineOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnlineOrder onlineOrder = db.OnlineOrders.Find(id);
            if (onlineOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiagID = new SelectList(db.Diagnosis, "DiagID", "Details", onlineOrder.DiagID);
            ViewBag.MedID = new SelectList(db.Medicines, "MedID", "MedName", onlineOrder.MedID);
            return View(onlineOrder);
        }

        // POST: OnlineOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,MedID,DiagID,Quantity")] OnlineOrder onlineOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onlineOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiagID = new SelectList(db.Diagnosis, "DiagID", "Details", onlineOrder.DiagID);
            ViewBag.MedID = new SelectList(db.Medicines, "MedID", "MedName", onlineOrder.MedID);
            return View(onlineOrder);
        }

        // GET: OnlineOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnlineOrder onlineOrder = db.OnlineOrders.Find(id);
            if (onlineOrder == null)
            {
                return HttpNotFound();
            }
            return View(onlineOrder);
        }

        // POST: OnlineOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OnlineOrder onlineOrder = db.OnlineOrders.Find(id);
            db.OnlineOrders.Remove(onlineOrder);
            db.SaveChanges();
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
