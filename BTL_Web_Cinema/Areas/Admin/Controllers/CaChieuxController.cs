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
    public class CaChieuxController : BaseController
    {
        private DBRapPhim_Context db = new DBRapPhim_Context();

        // GET: Admin/CaChieux
        public ActionResult Index()
        {
            return View(db.CaChieux.ToList());
        }

        // GET: Admin/CaChieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaChieu caChieu = db.CaChieux.Find(id);
            if (caChieu == null)
            {
                return HttpNotFound();
            }
            return View(caChieu);
        }

        // GET: Admin/CaChieux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CaChieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCa,TenCa")] CaChieu caChieu)
        {
            if (ModelState.IsValid)
            {
                db.CaChieux.Add(caChieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caChieu);
        }

        // GET: Admin/CaChieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaChieu caChieu = db.CaChieux.Find(id);
            if (caChieu == null)
            {
                return HttpNotFound();
            }
            return View(caChieu);
        }

        // POST: Admin/CaChieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCa,TenCa")] CaChieu caChieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caChieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caChieu);
        }

        // GET: Admin/CaChieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaChieu caChieu = db.CaChieux.Find(id);
            if (caChieu == null)
            {
                return HttpNotFound();
            }
            return View(caChieu);
        }

        // POST: Admin/CaChieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaChieu caChieu = db.CaChieux.Find(id);
            db.CaChieux.Remove(caChieu);
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
