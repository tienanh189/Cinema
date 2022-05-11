using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_Web_Cinema.Models.Entities;

namespace BTL_Web_Cinema.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }
        

        public ActionResult TEST()
        {
            return View();
        }

        public ActionResult RenderMain()
        {
            DBRapPhim_Context db = new DBRapPhim_Context();
            List<Phim> list=db.Phims.ToList();
            return PartialView("Main",list);
        }

        public ActionResult RenderMovieName(string mName)
        {
            DBRapPhim_Context db = new DBRapPhim_Context();
            List<Phim> list = db.Phims.Where(x=>x.TenPhim.Contains(mName)).ToList();
            return PartialView("Main", list);
        }

        public ActionResult RenderDetail(int? id)
        {
            DBRapPhim_Context db = new DBRapPhim_Context();
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

        public ActionResult MyTiket()
        {
            DBRapPhim_Context db = new DBRapPhim_Context();
            string name = (string)Session["UserName"];
            List<Ve> list = db.Ves.Where(x => x.UserName == name).ToList();
            return View(list);
        }

        public ActionResult GioChieu(int id)
        {
            DBRapPhim_Context db = new DBRapPhim_Context();
            List<LichChieu> list = db.LichChieux.Where(x => x.MaPhim == id).ToList();
            return PartialView("Time", list);
        }
        public ActionResult MuaVe(int MaSC,string tb)
        {
            Ve ve = new Ve(MaSC);
            ViewBag.tb = tb;
            return View(ve);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MuaVe(Ve ve)
        {
            DBRapPhim_Context db = new DBRapPhim_Context();
            if (ModelState.IsValid)
            {
                var kq = db.Ves.Where(x => x.SoGhe == ve.SoGhe && x.MaSuatChieu == ve.MaSuatChieu).ToList();
                if (kq.Count > 0)
                {
                    int ma = ve.MaSuatChieu.Value;
                    return RedirectToAction("MuaVe", new { MaSC = ma, tb = "Ghế này đã được đặt!!!" });
                }
                else
                {
                    ve.UserName = (string)Session["UserName"];
                    db.Ves.Add(ve);
                    db.SaveChanges();
                    return Redirect("~/Home/MyTiket");
                }
            }
            return View(ve);
        }

    }
}