using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Email { get; set; }
        public string BlogName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
