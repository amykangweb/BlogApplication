﻿using System;
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
        public static int lastIDNumber = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Post id.
        /// </summary>
        [Key]
        public int ID { get; private set; }
        /// <summary>
        /// Post title.
        /// </summary>
        [StringLength(255, ErrorMessage = "Post title cannot be more than 255 characters long.")]
        public string Title { get; set; }
        /// <summary>
        /// Post content.
        /// </summary>
        [StringLength(255, ErrorMessage = "Post content cannot be more than 255 characters long.")]
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
        #endregion
    }
}
