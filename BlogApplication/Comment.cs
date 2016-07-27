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

        #region Properties
        /// <summary>
        /// Comment id.
        /// </summary>
        [Key]
        public int Id { get; private set; }
        /// <summary>
        /// Comment content.
        /// </summary>
        [StringLength(255, ErrorMessage = "Comment cannot be more than 255 characters in length.")]
        public string Content { get; set; }
        /// <summary>
        /// Comment created at time.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        // Comment belongs to post.
        public virtual Post Post { get; set; }
        #endregion
    }
}
