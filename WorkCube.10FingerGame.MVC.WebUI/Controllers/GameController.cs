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
    [UserCheck]
    public class GameController : Controller
    {



        public ActionResult Index()
        {
            return View();
        }
        SkorRepository skorRepo = new SkorRepository();
        UserRepository userRepo = new UserRepository();
        public ActionResult Profile()
        {
            return View(userRepo.GetSingle(Convert.ToInt32(Helper.UserCheckAttribute.activeUserID)));
        }

        [HttpPost]
        public ActionResult Profile(FormCollection col)
        {
            User updateter = userRepo.GetSingle(Convert.ToInt32(Helper.UserCheckAttribute.activeUserID));
            updateter.Name = col["username"].ToString();
            updateter.Email = col["email"].ToString();
            updateter.Password = col["password"].ToString();
            userRepo.Update();
            return View(updateter);
        }


        [HttpGet]
        public JsonResult GetWordsJson()
        {
            string[] words = { "morbi", "id", "sem", "lorem", "donec", "dolor", "mi", "euismod", "id", "velit", "nec", "tristique", "placerat", "urna", "aenean", "sed", "felis", "sit", "amet", "ligula", "lobortis", "pellentesque", "quis", "vitae", "ante", "donec", "nec", "sollicitudin", "nunc", "curabitur", "quis", "elementum", "est", "ut", "condimentum", "dolor", "maecenas", "tempor", "a", "arcu", "sed", "placerat", "suspendisse", "potenti", "quisque", "tempor", "venenatis", "ante", "sed", "gravida", "nullam", "hendrerit", "elit", "molestie", "convallis", "efficitur", "praesent", "et", "ante", "eget", "libero", "ultrices", "cursus", "nec", "id", "dolor", "cras", "vel", "leo", "pretium", "magna", "iaculis", "tincidunt", "etiam", "viverra", "porttitor", "volutpat", "sed", "varius", "arcu", "tortor", "vivamus", "arcu", "velit", "vestibulum", "quis", "interdum", "sit", "amet", "ornare", "sit", "amet", "quam", "interdum", "et", "malesuada", "fames", "ac", "ante", "ipsum", "primis", "in", "faucibus", "donec", "ex", "ipsum", "facilisis", "pretium", "gravida", "a", "scelerisque", "sed", "arcu", "praesent", "purus", "lectus", "tempor", "sed", "tempus", "nec", "mollis", "sit", "amet", "ex", "mauris", "ut", "quam", "non", "felis", "ultrices", "mollis", "quis", "et", "velit", "praesent", "tempor", "ligula", "et", "dignissim", "ultrices", "diam", "ex", "lobortis", "odio", "nec", "pretium", "leo", "orci", "rhoncus", "nibh", "orci", "varius", "natoque", "penatibus", "et", "magnis", "dis", "parturient", "montes", "nascetur", "ridiculus", "mus", "donec", "porttitor", "gravida", "est", "vitae", "iaculis", "mi", "auctor", "placerat", "vivamus", "eleifend", "et", "quam", "et", "placerat", "maecenas", "molestie", "libero", "laoreet", "iaculis", "consectetur", "tellus", "purus", "egestas", "purus", "sed", "venenatis", "mauris", "justo", "sed", "metus", "pellentesque", "nec", "laoreet", "quam", "ut", "tempus", "porttitor", "interdum", "proin", "feugiat", "sollicitudin", "leo", "eget", "accumsan", "nullam", "ut", "nulla", "nec", "ante", "fermentum", "ultrices", "vitae", "sit", "amet", "mauris", "aliquam", "tristique", "enim", "convallis", "est", "aliquet", "ut", "sollicitudin", "mauris", "pellentesque", "morbi", "sapien", "enim", "pulvinar", "sit", "amet", "ante", "luctus", "euismod", "fringilla", "metus", "aliquam", "quis", "placerat", "nibh", "nulla", "et", "magna", "mi", "nam", "cursus", "ex", "ligula", "a", "pellentesque", "nisi", "consectetur", "in", "donec", "turpis", "sem", "efficitur", "nec", "nulla", "in", "faucibus", "rhoncus", "sem", "sed", "nec", "risus", "risus", "maecenas", "ultrices", "dolor", "ac", "odio", "pellentesque", "quis", "consectetur", "nisi", "imperdiet", "vestibulum", "sed", "auctor", "nisl", "in", "fermentum", "velit", "suspendisse", "eget", "lectus", "arcu", "curabitur", "aliquam", "gravida", "nibh", "vestibulum", "ante", "ipsum", "primis", "in", "faucibus", "orci", "luctus", "et", "ultrices", "posuere", "cubilia", "curae;", "donec", "sit", "amet", "tortor", "ultricies", "finibus", "risus", "a", "condimentum", "felis", "suspendisse", "blandit", "neque", "tellus", "at", "finibus", "ante", "suscipit", "vel", "in", "posuere", "magna", "ut", "efficitur", "aliquam", "etiam", "feugiat", "volutpat", "odio", "in", "tristique", "suspendisse", "potenti", "praesent", "non", "justo", "condimentum", "eleifend", "ex", "nec", "venenatis", "est", "vivamus", "pharetra", "nibh", "id", "dictum", "pellentesque", "orci", "velit", "euismod", "erat", "sed", "cursus", "lacus", "ante", "eu", "nisi", "ut", "eu", "tempus", "ex", "quis", "ornare", "arcu", "duis", "viverra", "neque", "id", "felis", "volutpat", "maximus", "lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit", "nam", "in", "aliquet", "enim", "nam", "sed", "rhoncus", "ligula", "vel", "placerat", "ex", "nunc", "dictum", "sed", "justo", "aliquam", "mattis", "integer", "sed", "nunc", "vitae", "mauris", "ultricies", "sollicitudin", "nunc", "condimentum", "tristique", "ultrices", "maecenas", "id", "condimentum", "libero", "non", "feugiat", "lacus", "donec", "quis", "erat", "ex", "cras", "eget", "mattis", "turpis", "maecenas", "tincidunt", "eu", "purus", "in", "lobortis", "vestibulum", "ut", "ultricies", "dolor", "vestibulum", "ornare", "lacus", "sed", "orci", "placerat", "ornare", "donec", "quis", "tincidunt", "mauris", "quis", "ornare", "sapien", "vestibulum", "eget", "justo", "ut", "justo", "pellentesque", "pretium", "ut", "ac", "felis", "vivamus", "sit", "amet", "tristique", "dui", "phasellus", "auctor", "eu", "orci", "blandit", "lobortis", "cras", "dignissim", "et", "mauris", "eu", "porta", "maecenas", "id", "justo", "luctus", "auctor", "lorem", "eu", "facilisis", "orci", "pellentesque", "faucibus", "neque", "vehicula", "laoreet", "hendrerit", "elit", "leo", "euismod" };
            Random rnd = new Random();
            string[] MyRandomWord = words.OrderBy(x => rnd.Next()).ToArray();

            return Json(MyRandomWord, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SetSkor(Skor skor)
        {


            skor.UserID = Convert.ToInt32(UserCheckAttribute.activeUserID);
            skorRepo.Insert(skor);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Istatistic()
        {
            return View(skorRepo.GetAll().Where(x => x.UserID == Convert.ToInt32(UserCheckAttribute.activeUserID)).ToList());
        }
    }
}
