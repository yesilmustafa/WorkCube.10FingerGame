using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace WorkCube._10FingerGame.MVC.WebUI.Helper  //helper sınıfımızı yardımcı sınıf olarak açtık.
{
    public class UserCheckAttribute : ActionFilterAttribute, IActionFilter
    {
        public static string activeUser;
        public static string activeUserID;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(activeUser))
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
        }
    }
}