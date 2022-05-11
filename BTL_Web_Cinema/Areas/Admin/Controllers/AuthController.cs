using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_Web_Cinema.Models.Entities;

namespace BTL_Web_Cinema.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Admin/Auth
        public ActionResult Login()
        {
            if (!Session["UserAdmin"].Equals(""))
            {
                return RedirectToAction("Index", "Phims");
            }
            ViewBag.Eror="";
            return View();         
        }
        [HttpPost]
        public ActionResult Login(FormCollection feild)
        {
            DBRapPhim_Context db = new DBRapPhim_Context();
            string eror = "";
            string username = feild["username"];
            string password = feild["password"];
            var data = db.Users.Where(x => x.UserName == username && x.Password == password).ToList();
            if (data.Count>0)        
            {
                if (username=="Admin")
                {
                    Session["UserAdmin"] = username;
                    return RedirectToAction("Index", "Phims");
                }
            }
            
            eror = "Sai tên tài khoản hoặc mật khẩu!!!";
            
            ViewBag.Eror = eror;
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserAdmin"] = "";
            return RedirectToAction("Login", "Auth");
        }
    }
}