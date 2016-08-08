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
            var account = HttpContext.User.Identity.Name;
            var authorProfile = db.Authors.Where(a => a.Email == account).FirstOrDefault();

            // Don't allow users without author records to view create post page.
            if(authorProfile == null)
            {
                return RedirectToAction("Index", "Home");
            }

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
        public ActionResult Detail(int? id)
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

        // GET: Edit post view.
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var post = db.Posts.Where(f => f.Id == id).FirstOrDefault();

            if(post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Update Post Action.
        public ActionResult Edit([Bind(Include = "Id, Title, Content, TypeOfPost")]Post post)
        {
            var current = HttpContext.User.Identity.Name;
            var original = db.Posts.Where(i => i.Id == post.Id).FirstOrDefault();

            if(ModelState.IsValid && current == original.AccountEmail)
            {
                original.Title = post.Title;
                original.Content = post.Content;
                original.TypeOfPost = post.TypeOfPost;
                db.SaveChanges();
                return RedirectToAction("Detail", "Posts", new { id = post.Id });
            }

            return View(post);
        }
    }

}