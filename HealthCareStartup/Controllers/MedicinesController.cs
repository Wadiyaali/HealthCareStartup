﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HealthCareStartup.Models;

namespace HealthCareStartup.Controllers
{
    public class MedicinesController : ApiController
    {
        private OEL2Entities db = new OEL2Entities();

        // GET: api/Medicines
        public IQueryable<Medicine> GetMedicines()
        {
            return db.Medicines;
        }

        // GET: api/Medicines/5
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult GetMedicine(int id)
        {
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return NotFound();
            }

            return Ok(medicine);
        }

        // PUT: api/Medicines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicine(int id, Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicine.MedID)
            {
                return BadRequest();
            }

            db.Entry(medicine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Medicines
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult PostMedicine(Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicines.Add(medicine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicine.MedID }, medicine);
        }

        // DELETE: api/Medicines/5
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult DeleteMedicine(int id)
        {
            Medicine medicine = db.Medicines.Find(id);
            if (medicine == null)
            {
                return NotFound();
            }

            db.Medicines.Remove(medicine);
            db.SaveChanges();

            return Ok(medicine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicineExists(int id)
        {
            return db.Medicines.Count(e => e.MedID == id) > 0;
        }
    }
}