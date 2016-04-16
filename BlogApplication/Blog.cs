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
        ///  Temporarily store posts and comments with lists.
        /// </summary>
        #region Lists
        public static List<Post> AllPosts = new List<Post>();
        public static List<Comment> AllComments = new List<Comment>();
        #endregion

        /// <summary>
        /// Create Post Method
        /// </summary>
        /// <param name="content">Post content.</param>
        /// <param name="status">Status of Post. Private/Public</param>
        /// <returns></returns>
        public static Post CreatePost(string title, string content, string status)
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
                CreatedAt = DateTime.Now
            };

            AllPosts.Add(post);
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
            var comment = new Comment
            {
                Content = content,
                PostID = postid,
                CreatedAt = DateTime.Now
            };

            AllComments.Add(comment);
            return comment;

        }
    }
}
