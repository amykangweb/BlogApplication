using BlogApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace BlogApplicationUI.Controllers
{
    public class PostsController : Controller
    {
        private BlogModel db = new BlogModel();

        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Where(c => c.TypeOfPost == PrivatePost.Public).Include(a => a.Author).ToList();

            return View(posts);
        }

        // Create View
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // Create Action
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Title,Content,TypeOfPost")] Post post)
        {
            if(ModelState.IsValid)
            {
                var account = HttpContext.User.Identity.Name;
                Blog.CreatePost(post.Title, post.Content, post.TypeOfPost.ToString(), account);
                return RedirectToAction("Index", "Blog");
            }

            return View("Index");
        }

        // GET: Get Post page.
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            Comment comment = new Comment();
            var comments = db.Comments.Where(c => c.AccountEmail == post.AccountEmail).Include(a => a.Author).ToList();

            if(post == null)
            {
                return HttpNotFound();
            }
            Session.Add("BlogName", post.Author.BlogName);
            Session.Add("PostId", post.Id);
            return View(Tuple.Create(post, comment, comments));
        }
    }

}