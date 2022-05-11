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
    public class UsersController : Controller
    {
        public ActionResult SignUp(string tb)
        {
            ViewBag.tb = tb;
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            DBRapPhim_Context db = new DBRapPhim_Context();
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var data = db.Users.Where(x => x.UserName == user.UserName).ToList();
                if (data.Count>0)
                {
                    return RedirectToAction("SignUp", new { tb="Tên đăng nhập đã tồn tại!!!" });
                }              
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("SignIn");       
            }
        }
        public ActionResult SignIn(string tb)
        {
            if (Session["UserName"]!=null)
            {
                return Redirect("~/Home/Index");
            }
            if (Request.Cookies["uname"] !=null && Request.Cookies["pass"]!=null)
            {
                ViewBag.user = Request.Cookies["uname"].Value;
                ViewBag.pass = Request.Cookies["pass"].Value;
            }
            ViewBag.tb = tb;
            return View();
        }
        [HttpGet]
        public ActionResult SigninCheck(string username, string password, string rememberUser)
        {
            DBRapPhim_Context db = new DBRapPhim_Context();
            var data = db.Users.Where(x => x.UserName == username && x.Password == password).ToList();
            if (data.Count>0)
            {
                if (rememberUser!=null)
                {                 
                    Response.Cookies["uname"].Value = username;
                    Response.Cookies["pass"].Value = password;
                    Response.Cookies["uname"].Expires = DateTime.Now.AddSeconds(60);
                    Response.Cookies["pass"].Expires = DateTime.Now.AddSeconds(60);
                }
                else
                {
                    Response.Cookies["uname"].Expires = DateTime.Now.AddSeconds(-60);
                    Response.Cookies["pass"].Expires = DateTime.Now.AddSeconds(-60);
                }
                Session["UserName"]=data.FirstOrDefault().UserName;
                return Redirect("~/Home/Index");
            }
            return RedirectToAction("SignIn", new {tb="Thông tin đăng nhập sai"});
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("SignIn");
        }
    }
}
