using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public static BlogModel db = new BlogModel();
        #endregion

        #region Properties
        /// <summary>
        /// Post id.
        /// </summary>
        [Key]
        public int Id { get; private set; }
        /// <summary>
        /// Post title.
        /// </summary>
        [StringLength(255, ErrorMessage = "Post title cannot be more than 255 characters long.")]
        public string Title { get; set; }
        /// <summary>
        /// Post content.
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Post created at time.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        public PrivatePost TypeOfPost { get; set; }
        // Author email.
        public string AccountEmail { get; set; }
        // Post has many comments.
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Author Author { get; set; }
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

        public static Post[] GetAllPosts()
        {
            return db.Posts.ToArray();
        }
        #endregion
    }
}
