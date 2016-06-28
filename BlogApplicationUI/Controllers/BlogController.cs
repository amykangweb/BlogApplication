using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogApplicationUI.Models;
using BlogApplication;

namespace BlogApplicationUI.Controllers
{
    public class BlogController : Controller
    {
        private BlogModel db = new BlogModel();

        // GET: Blog for current user.
        [Authorize]
        public ActionResult Index()
        {
            var account = HttpContext.User.Identity.Name;
            var user = db.Authors.Where(a => a.Email == account).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Create");
            }
            
            var posts = db.Posts.Where(a => a.AccountEmail == account);
            return View(posts);
        }

        // GET: Create Blog form.
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Blog.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserName,BlogName")] Author author)
        {
            if (ModelState.IsValid)
            {
                var account = HttpContext.User.Identity.Name;
                Blog.CreateAuthor(author.AuthorName, account.ToString(), author.BlogName);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Individual Blog for non-signed in users.
        // public ActionResult Detail()
        //{

        //}
    }
}