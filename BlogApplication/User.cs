using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication
{
    /// <summary>
    /// This is the user class.
    /// </summary>
    public class User
    {
        #region Variables
        private static int lastIDNumber = 0;
        #endregion

        #region Properties
        /// <summary>
        /// User id
        /// </summary>
        public int UserID { get; private set; }
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
        #endregion

        #region Constructor
        private User()
        {
            UserID = ++lastIDNumber;
        }
        #endregion

        #region Methods
        #endregion
    }
}
