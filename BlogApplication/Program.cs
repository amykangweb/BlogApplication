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
            var user = new User();
            user.ID = 1;
            user.Email = "amy@mail.com";
            user.Name = "Amy";
            user.Password = "password";

            var post = new Post();
            post.UserId = user.ID;
            post.Title = "Hello, World!";
            post.Content = "Lorem ipsum is commonly used as placeholder text.";
            post.TypeOfPost = PrivatePost.Private;
            post.CreatedAt = DateTime.Now;

            var post2 = new Post();
            post2.UserId = user.ID;
            post2.Title = "Second Post!";
            post2.Content = "Lorem ipsum is commonly used as placeholder text.";
            post2.TypeOfPost = PrivatePost.Public;
            post2.CreatedAt = DateTime.Now;

            Console.WriteLine("Username: {0}, Title: {1}, Content: {2}, Created At: {3}", 
                user.Name, post.Title, post.GetPost(), post.CreatedAt);

            Console.WriteLine("Username: {0}, Title: {1}, Content: {2}, Created At: {3}",
                user.Name, post2.Title, post2.GetPost(), post2.CreatedAt);
            Console.Read();
        }
    }
}
