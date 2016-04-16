using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            var post = new Post();
            post.Title = "Hello, World!";
            post.Content = "Lorem ipsum is commonly used as placeholder text.";
            post.TypeOfPost = PrivatePost.Private;
            post.CreatedAt = DateTime.Now;

            var post2 = new Post();
            post2.Title = "Second Post!";
            post2.Content = "Lorem ipsum is commonly used as placeholder text.";
            post2.TypeOfPost = PrivatePost.Public;
            post2.CreatedAt = DateTime.Now;

            var comment = new Comment();
            comment.CreateComment("This is a comment.", post2.PostID);

            Console.WriteLine("Title: {1}, Content: {2}, Created At: {3}", post.Title, post.GetPost(), post.CreatedAt);

            Console.WriteLine("Title: {1}, Content: {2}, Created At: {3}",
                post2.Title, post2.GetPost(), post2.CreatedAt);

            Console.WriteLine("Comment: {0}, Post: {2}, Created At: {3}", comment.Content, comment.PostID, comment.CreatedAt);

            Console.Read();
        }
    }
}
