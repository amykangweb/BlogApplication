using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication
{
    /// <summary>
    /// Class for comments.
    /// </summary>
    public class Comment
    {
        #region Variables
        private static int lastIDNumber = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Comment id.
        /// </summary>
        public int CommentID { get; private set; }
        /// <summary>
        /// Comment user id.
        /// </summary>
        public int UserID { get; private set; }
        /// <summary>
        /// Comment post id.
        /// </summary>
        public int PostID { get; private set; }
        /// <summary>
        /// Comment content.
        /// </summary>
        public string Content { get; private set; }
        /// <summary>
        /// Comment created at time.
        /// </summary>
        public DateTime CreatedAt { get; private set; }
        #endregion

        #region Constructor
        public Comment()
        {
            CommentID = ++lastIDNumber;
        }
        #endregion

        #region Methods
        public void CreateComment(string comment, int post, int user)
        {
            Content = comment;
            PostID = post;
            UserID = user;
            CreatedAt = DateTime.Now;
        }
        #endregion
    }
}
