using BlogApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace BlogApplicationUI.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        // POST: Create comment action.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Content)
        {
            string blogName = Session["BlogName"].ToString();
            int postId = Convert.ToInt32(Session["PostId"]);

            if(ModelState.IsValid)
            {
                var account = HttpContext.User.Identity.Name;
                Blog.CreateComment(Content, postId);
                return RedirectToAction("Details", "Posts", new { id = postId });
            }

            return RedirectToAction("Detail", "Blog", new { blog = blogName });
        }
    }
}