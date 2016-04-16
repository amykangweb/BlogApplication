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
        /// Create Post Method
        /// </summary>
        /// <param name="content">Post content.</param>
        /// <returns></returns>
        public static Post CreatePost(string content)
        {
            var post = new Post
            {
                Content = content,
                CreatedAt = DateTime.Now
            };

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

            return comment;

        }
    }
}
