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
        public int PostID { get; private set; }
        /// <summary>
        /// Post user id.
        /// </summary>
        public int UserId { get; set; }
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
            PostID = ++lastIDNumber;
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
        #endregion
    }
}
