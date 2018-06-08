using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkCube._10FingerGame.BLL.Repositories;
using WorkCube._10FingerGame.Entity.Entities;
using WorkCube._10FingerGame.MVC.WebUI.Helper;

namespace WorkCube._10FingerGame.MVC.WebUI.Controllers
{
    public class HomeController : Controller
    {
        UserRepository userrepo = new UserRepository();
        public ActionResult Index()
        {
            if (Session["activeUser"] != null)  //kullanıcının giriş yapıp yapmadığını ActiveUser ile kontrol ediyoruz.
            {
                return RedirectToAction("Index", "Game");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection col) //Kullanıcı adı ve şifreyi yakalayabilmemiz için gerekli işlemler.
        {
            
            User result = userrepo.UserCheck(col["uname"].ToString(), col["psw"].ToString());

            if (result !=null)
            {
                Session["activeUser"] = col["uname"].ToString();
                UserCheckAttribute.activeUser = result.Name;
                UserCheckAttribute.activeUserID = result.ID.ToString();
                return RedirectToAction("Index", "Game");
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection col)
        {
            if (Session["activeUser"] != null)
            {
                return RedirectToAction("Index", "Game");
            }
            User user = new User();
            user.Name = col["username"].ToString();
            user.Email = col["email"].ToString();
            user.Password = col["password"].ToString();
            userrepo.Insert(user);
            Session["activeUser"] = user.Name;
            UserCheckAttribute.activeUser = user.Name;
            return RedirectToAction("Index", "Game");
        }

        [UserCheck]
        public ActionResult Logout()
        {
            Session["activeUser"] = null;
            UserCheckAttribute.activeUser = null;
            UserCheckAttribute.activeUserID = null;
            return RedirectToAction("Index", "Home");
        }
    }
}