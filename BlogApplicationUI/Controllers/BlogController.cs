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
            // Redirect to Create action if user does not have an author record.
            if (user == null)
            {
                return RedirectToAction("Create");
            }
            
            var posts = db.Posts.Where(a => a.AccountEmail == account);
            @ViewData["BlogName"] = user.BlogName;
            return View(posts);
        }

        // GET: Create Blog form.
        [Authorize]
        public ActionResult Create()
        {
            // Check if current user already has author record.
            var account = HttpContext.User.Identity.Name;
            var blogAuthor = db.Authors.Where(a => a.Email == account).FirstOrDefault();
            // Redirect to blog index page if current user already has author record.
            if(blogAuthor != null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // POST: Create Blog.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserName,BlogName")] Author author)
        {
            // Check if current user already has author record.
            var account = HttpContext.User.Identity.Name;
            var blogAuthor = db.Authors.Where(a => a.Email == account).FirstOrDefault();

            // Only allow creation of author record if user does not have author record.
            if (ModelState.IsValid && (blogAuthor == null))
            {
                Blog.CreateAuthor(author.AuthorName, account.ToString(), author.BlogName);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Individual Blog for non-signed in users.
        public ActionResult Detail(string blog)
        {
            var author = db.Authors.Where(a => a.BlogName == blog).FirstOrDefault();
            var posts = db.Posts.Where(a => a.AccountEmail == author.Email);
            @ViewData["BlogName"] = author.BlogName;
            @ViewData["AuthorName"] = author.AuthorName;
            return View(posts);
        }
    }
}