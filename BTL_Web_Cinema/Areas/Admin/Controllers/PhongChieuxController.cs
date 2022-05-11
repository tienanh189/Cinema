using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_Web_Cinema.Models.Entities;

namespace BTL_Web_Cinema.Areas.Admin.Controllers
{
    public class PhongChieuxController : BaseController
    {
        private DBRapPhim_Context db = new DBRapPhim_Context();

        // GET: Admin/PhongChieux
        public ActionResult Index()
        {
            return View(db.PhongChieux.ToList());
        }

        // GET: Admin/PhongChieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongChieu phongChieu = db.PhongChieux.Find(id);
            if (phongChieu == null)
            {
                return HttpNotFound();
            }
            return View(phongChieu);
        }

        // GET: Admin/PhongChieux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhongChieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhongChieu,TenPhong")] PhongChieu phongChieu)
        {
            if (ModelState.IsValid)
            {
                db.PhongChieux.Add(phongChieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phongChieu);
        }

        // GET: Admin/PhongChieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongChieu phongChieu = db.PhongChieux.Find(id);
            if (phongChieu == null)
            {
                return HttpNotFound();
            }
            return View(phongChieu);
        }

        // POST: Admin/PhongChieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhongChieu,TenPhong")] PhongChieu phongChieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongChieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongChieu);
        }

        // GET: Admin/PhongChieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongChieu phongChieu = db.PhongChieux.Find(id);
            if (phongChieu == null)
            {
                return HttpNotFound();
            }
            return View(phongChieu);
        }

        // POST: Admin/PhongChieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhongChieu phongChieu = db.PhongChieux.Find(id);
            db.PhongChieux.Remove(phongChieu);
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
