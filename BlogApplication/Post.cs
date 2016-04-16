using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication
{
    public enum PrivatePost
    {
        Public,
        Private
    }
    /// <summary>
    /// User posts.
    /// </summary>
    public class Post
    {
        #region Variables
        public static int lastIDNumber = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Post id.
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Post title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Post content.
        /// </summary>
        public string Content { private get; set; }
        /// <summary>
        /// Post created at time.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        public PrivatePost TypeOfPost { get; set; }

        #endregion

        #region Constructor
        public Post()
        {
            ID = ++lastIDNumber;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Post methods.
        /// </summary>
        public string GetPost()
        {
            if(TypeOfPost == PrivatePost.Public)
            {
                return Content;
            } else
            {
                return "Error. This post is private.";
            }
        }
        /// <summary>
        /// Return all blog posts. Only show public posts.
        /// </summary>
        public static void PrintAll()
        {
            foreach(var post in Blog.AllPosts)
            {
                if (post.TypeOfPost == PrivatePost.Public)
                {
                    Console.WriteLine("Id: {0}", post.ID);
                    Console.WriteLine("Title: {0}", post.Title);
                    Console.WriteLine("Content: {0}", post.GetPost());

                    // Find and show all comments with PostID of post.ID
                    var comments = Blog.AllComments.Where<Comment>(f => f.PostID == post.ID);
                    foreach(var comment in comments)
                    {
                        Console.WriteLine("Post Comments:");
                        Console.WriteLine(comment.Content);
                    }

                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine("Error. This post is private.");
                }

            }
        }
        #endregion
    }
}
