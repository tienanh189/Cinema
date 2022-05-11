using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_Web_Cinema.Models.Entities;

namespace BTL_Web_Cinema.Controllers
{
    public class LichChieuxController : Controller
    {
        private DBRapPhim_Context db = new DBRapPhim_Context();
        public ActionResult DatVe()
        {
            var phims = db.Phims.Include(p => p.TheLoai);
            return View(phims.ToList());
        }

        public ActionResult GioChieu(int id)
        {
            List<LichChieu> list = db.LichChieux.Where(x => x.MaPhim == id).ToList();
            return PartialView("Time",list);
        }

        public ActionResult MuaVe(int MaSC, string tb)
        {
            Ve ve = new Ve(MaSC);
            ViewBag.tb = tb;
            return View(ve);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MuaVe(Ve ve)
        {
            if (ModelState.IsValid)
            {
                var kq = db.Ves.Where(x => x.SoGhe == ve.SoGhe && x.MaSuatChieu==ve.MaSuatChieu).ToList();
                if (kq.Count > 0)
                {
                    int ma = ve.MaSuatChieu.Value;
                    return RedirectToAction("MuaVe", new {MaSC=ma,tb = "Ghế này đã được đặt!!!" });
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
