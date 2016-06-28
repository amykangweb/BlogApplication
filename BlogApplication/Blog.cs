using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication
{
    public static class Blog
    {
        /// <summary>
        ///  Create db for BlogApplication.
        /// </summary>
        #region Variables
        public static BlogModel db = new BlogModel();
        #endregion

        /// <summary>
        /// Checks if any Posts exist.
        /// </summary>
        /// <returns>True or False</returns>
        public static Boolean PostsExist() {
            if(db.Posts.Count<Post>() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Author CreateAuthor(string name, string email, string blog)
        {
            var author = new Author
            {
                AuthorName = name,
                Email = email,
                BlogName = blog
            };

            db.Authors.Add(author);
            db.SaveChanges();
            return author;
        }
        /// <summary>
        /// Create Post Method
        /// </summary>
        /// <param name="content">Post content.</param>
        /// <param name="status">Status of Post. Private/Public</param>
        /// <returns></returns>
        public static Post CreatePost(string title, string content, string status, string email)
        {
            PrivatePost poststatus;

            if (status.ToLower() == "private")
            {
                poststatus = PrivatePost.Private;
            } else {
                poststatus = PrivatePost.Public;
            }

            var post = new Post
            {
                Title = title,
                Content = content,
                TypeOfPost = poststatus,
                CreatedAt = DateTime.Now,
                AccountEmail = email
            };

            db.Posts.Add(post);
            db.SaveChanges();
            return post;

        }

        /// <summary>
        /// Create Comment Method
        /// </summary>
        /// <param name="content">Comment Content</param>
        /// <param name="postid">Comment Post id</param>
        /// <returns></returns>
        public static Comment CreateComment(string content, int postid)
        {
            var post = db.Posts.Where(c => c.Id == postid).FirstOrDefault();
            var comment = new Comment
            {
                Content = content,
                Post = post,
                CreatedAt = DateTime.Now
            };

            db.Comments.Add(comment);
            db.SaveChanges();
            return comment;

        }
    }
}
