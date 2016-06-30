using BlogApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApplicationUI.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        public ActionResult Index()
        {
            var posts = Post.GetAllPosts();
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
    }

}