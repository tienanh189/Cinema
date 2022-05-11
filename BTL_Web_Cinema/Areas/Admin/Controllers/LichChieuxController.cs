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
    public class LichChieuxController : BaseController
    {
        private DBRapPhim_Context db = new DBRapPhim_Context();

        // GET: Admin/LichChieux
        public ActionResult Index()
        {
            var lichChieux = db.LichChieux.Include(l => l.CaChieu1).Include(l => l.Phim).Include(l => l.PhongChieu);
            return View(lichChieux.ToList());
        }

        // GET: Admin/LichChieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichChieu lichChieu = db.LichChieux.Find(id);
            if (lichChieu == null)
            {
                return HttpNotFound();
            }
            return View(lichChieu);
        }

        // GET: Admin/LichChieux/Create
        public ActionResult Create()
        {
            ViewBag.CaChieu = new SelectList(db.CaChieux, "MaCa", "TenCa");
            ViewBag.MaPhim = new SelectList(db.Phims, "MaPhim", "TenPhim");
            ViewBag.SoPhongChieu = new SelectList(db.PhongChieux, "SoPhongChieu", "TenPhong");
            return View();
        }

        // POST: Admin/LichChieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSuatChieu,NgayChieu,CaChieu,SoPhongChieu,TienVe,MaPhim")] LichChieu lichChieu)
        {
            if (ModelState.IsValid)
            {
                db.LichChieux.Add(lichChieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CaChieu = new SelectList(db.CaChieux, "MaCa", "TenCa", lichChieu.CaChieu);
            ViewBag.MaPhim = new SelectList(db.Phims, "MaPhim", "TenPhim", lichChieu.MaPhim);
            ViewBag.SoPhongChieu = new SelectList(db.PhongChieux, "SoPhongChieu", "TenPhong", lichChieu.SoPhongChieu);
            return View(lichChieu);
        }

        // GET: Admin/LichChieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichChieu lichChieu = db.LichChieux.Find(id);
            if (lichChieu == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaChieu = new SelectList(db.CaChieux, "MaCa", "TenCa", lichChieu.CaChieu);
            ViewBag.MaPhim = new SelectList(db.Phims, "MaPhim", "TenPhim", lichChieu.MaPhim);
            ViewBag.SoPhongChieu = new SelectList(db.PhongChieux, "SoPhongChieu", "TenPhong", lichChieu.SoPhongChieu);
            return View(lichChieu);
        }

        // POST: Admin/LichChieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSuatChieu,NgayChieu,CaChieu,SoPhongChieu,TienVe,MaPhim")] LichChieu lichChieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichChieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CaChieu = new SelectList(db.CaChieux, "MaCa", "TenCa", lichChieu.CaChieu);
            ViewBag.MaPhim = new SelectList(db.Phims, "MaPhim", "TenPhim", lichChieu.MaPhim);
            ViewBag.SoPhongChieu = new SelectList(db.PhongChieux, "SoPhongChieu", "TenPhong", lichChieu.SoPhongChieu);
            return View(lichChieu);
        }

        // GET: Admin/LichChieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichChieu lichChieu = db.LichChieux.Find(id);
            if (lichChieu == null)
            {
                return HttpNotFound();
            }
            return View(lichChieu);
        }

        // POST: Admin/LichChieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LichChieu lichChieu = db.LichChieux.Find(id);
            db.LichChieux.Remove(lichChieu);
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
