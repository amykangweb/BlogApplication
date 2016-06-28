using BlogApplication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogApplicationUI.Controllers
{
    public class HomeController : Controller
    {
        private BlogModel db = new BlogModel();

        public ActionResult Index()
        {
            // dynamic model = new ExpandoObject();
            // model.Posts = db.Posts.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}