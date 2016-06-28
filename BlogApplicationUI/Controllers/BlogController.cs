using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogApplicationUI.Models;


namespace BlogApplicationUI.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog for current user.
        [Authorize]
        public ActionResult Index()
        {
            var account = HttpContext.User.Identity.Name;
            var posts = db.Posts.Where(a => a.AccountEmail == account);
            return View(posts);
        }

        // GET: Individual Blog for non-signed in users.
        // public ActionResult Detail()
        //{

        //}
    }
}