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
        #region Properties
        /// <summary>
        /// Comment id.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Comment user id.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Comment post id.
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// Comment content.
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Comment created at time.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        #endregion
    }
}
