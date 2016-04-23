using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int ID { get; private set; }
        /// <summary>
        /// Comment post id.
        /// </summary>
        public int PostID { get; set; }
        /// <summary>
        /// Comment content.
        /// </summary>
        [StringLength(255, ErrorMessage = "Comment cannot be more than 255 characters in length.")]
        public string Content { get; set; }
        /// <summary>
        /// Comment created at time.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        #endregion

        #region Constructor
        public Comment()
        {
            ID = ++lastIDNumber;
        }
        #endregion
    }
}
