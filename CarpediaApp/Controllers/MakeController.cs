using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarpediaApp.Models;

namespace CarpediaApp.Controllers
{
    public class MakeController : Controller
    {
        private vehicles_DBEntities db = new vehicles_DBEntities();

        // GET: Make
        public ActionResult Index()
        {
            return View(db.VehicleMake.ToList());
        }

        // GET: Make/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehicleMake.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: Make/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Make/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MakeID,MakeName,MakeAbrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                db.VehicleMake.Add(vehicleMake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleMake);
        }

        // GET: Make/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehicleMake.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: Make/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MakeID,MakeName,MakeAbrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleMake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: Make/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehicleMake.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: Make/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleMake vehicleMake = db.VehicleMake.Find(id);
            db.VehicleMake.Remove(vehicleMake);
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
