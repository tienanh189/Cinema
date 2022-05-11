using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_Web_Cinema.Models.Entities;

namespace BTL_Web_Cinema.Areas.Admin.Controllers
{
    public class PhimsController : BaseController
    {
        private DBRapPhim_Context db = new DBRapPhim_Context();

        // GET: Admin/Phims
        public ActionResult Index(int? page)
        {
            var phims = (from s in db.Phims select s);
            if (page>0)
            {
                page = page;
            }else page = 1;

            int limit = 2;
            int start = (int)(page-1)*limit;
            int totalMovies = phims.Count();
            ViewBag.totalMovies = totalMovies;
            ViewBag.pageCurrent = page;
            float numberPage = ((float)totalMovies /limit);
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var data=phims.OrderByDescending(s=>s.MaPhim).Skip(start).Take(limit);
            return View(data.ToList());
        }

        // GET: Admin/Phims/Details/5
        public ActionResult Details(int? id)
        {          
            return View(db.Phims.Where(s=>s.MaPhim==id).FirstOrDefault());
        }

        // GET: Admin/Phims/Create
        public ActionResult Create()
        {
            Phim phim = new Phim();
            ViewBag.MaLoai = new SelectList(db.TheLoais, "MaLoai", "TenTheLoai");
            return View(phim);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Phim phim)
        {
            if (ModelState.IsValid)
            {
                if (phim.ImageUpLoad!=null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(phim.ImageUpLoad.FileName);
                    string exten = Path.GetExtension(phim.ImageUpLoad.FileName);
                    fileName = fileName + exten;
                    phim.Anh = fileName;
                    phim.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileName));
                }
                db.Phims.Add(phim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.TheLoais, "MaLoai", "TenTheLoai", phim.MaLoai);
            return View(phim);
        }

        // GET: Admin/Phims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.TheLoais, "MaLoai", "TenTheLoai", phim.MaLoai);
            return View(phim);
        }

        // POST: Admin/Phims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Phim phim)
        {
            if (ModelState.IsValid)
            {
                if (phim.ImageUpLoad != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(phim.ImageUpLoad.FileName);
                    string exten = Path.GetExtension(phim.ImageUpLoad.FileName);
                    fileName = fileName + exten;
                    phim.Anh = fileName;
                    phim.ImageUpLoad.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileName));
                }
                db.Entry(phim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.TheLoais, "MaLoai", "TenTheLoai", phim.MaLoai);
            return View(phim);
        }

        // GET: Admin/Phims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phim phim = db.Phims.Find(id);
            if (phim == null)
            {
                return HttpNotFound();
            }
            return View(phim);
        }

        // POST: Admin/Phims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phim phim = db.Phims.Find(id);
            db.Phims.Remove(phim);
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
