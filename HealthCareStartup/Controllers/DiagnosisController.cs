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
    public class DiagnosisController : Controller
    {
        private OEL2Entities db = new OEL2Entities();

        // GET: Diagnosis
        public ActionResult Index()
        {
            var diagnosis = db.Diagnosis.Include(d => d.Doctor).Include(d => d.Hospital).Include(d => d.Patient);
            return View(diagnosis.ToList());
        }

        // GET: Diagnosis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnosi diagnosi = db.Diagnosis.Find(id);
            if (diagnosi == null)
            {
                return HttpNotFound();
            }
            return View(diagnosi);
        }

        // GET: Diagnosis/Create
        public ActionResult Create()
        {
            ViewBag.DocID = new SelectList(db.Doctors, "DId", "DName");
            ViewBag.HospID = new SelectList(db.Hospitals, "HId", "HName");
            ViewBag.PatID = new SelectList(db.Patients, "PId", "Pname");
            return View();
        }

        // POST: Diagnosis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiagID,DocID,PatID,HospID,Details,Results")] Diagnosi diagnosi)
        {
            if (ModelState.IsValid)
            {
                db.Diagnosis.Add(diagnosi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocID = new SelectList(db.Doctors, "DId", "DName", diagnosi.DocID);
            ViewBag.HospID = new SelectList(db.Hospitals, "HId", "HName", diagnosi.HospID);
            ViewBag.PatID = new SelectList(db.Patients, "PId", "Pname", diagnosi.PatID);
            return View(diagnosi);
        }

        // GET: Diagnosis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnosi diagnosi = db.Diagnosis.Find(id);
            if (diagnosi == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocID = new SelectList(db.Doctors, "DId", "DName", diagnosi.DocID);
            ViewBag.HospID = new SelectList(db.Hospitals, "HId", "HName", diagnosi.HospID);
            ViewBag.PatID = new SelectList(db.Patients, "PId", "Pname", diagnosi.PatID);
            return View(diagnosi);
        }

        // POST: Diagnosis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiagID,DocID,PatID,HospID,Details,Results")] Diagnosi diagnosi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnosi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocID = new SelectList(db.Doctors, "DId", "DName", diagnosi.DocID);
            ViewBag.HospID = new SelectList(db.Hospitals, "HId", "HName", diagnosi.HospID);
            ViewBag.PatID = new SelectList(db.Patients, "PId", "Pname", diagnosi.PatID);
            return View(diagnosi);
        }

        // GET: Diagnosis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnosi diagnosi = db.Diagnosis.Find(id);
            if (diagnosi == null)
            {
                return HttpNotFound();
            }
            return View(diagnosi);
        }

        // POST: Diagnosis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diagnosi diagnosi = db.Diagnosis.Find(id);
            db.Diagnosis.Remove(diagnosi);
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
