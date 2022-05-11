using System.Web.Mvc;

namespace BTL_Web_Cinema.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               "AdminLogin",
               "Admin/Login",
               new { Controller="Auth" ,action = "Login", id = UrlParameter.Optional }
           );

          
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { Controller = "Phims", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}