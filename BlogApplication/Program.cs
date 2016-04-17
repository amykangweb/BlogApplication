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
            Console.WriteLine("Welcome to Blog Application!");
            string answer;

            do
            {
                Console.WriteLine("Please choose one of the options.");
                Console.WriteLine("1. View all posts.");
                Console.WriteLine("2. Create a new post.");
                Console.WriteLine("3. Create a comment.");
                Console.WriteLine("0. Exit program.");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.WriteLine("Printing out all posts.");
                        PrintAllPosts();
                        break;

                    case "2":
                        Console.WriteLine("Enter post title.");
                        var title = Console.ReadLine();
                        Console.WriteLine("Enter post content.");
                        var content = Console.ReadLine();
                        Console.WriteLine("Enter post status. Private or Public.");
                        var status = Console.ReadLine();
                        var post = Blog.CreatePost(title, content, status);
                        PrintAllPosts();
                        break;

                    case "3":
                        if (Blog.AllPosts.Count == 0)
                        {
                            Console.WriteLine("No posts exist to comment on.");
                            break;
                        }
                        PrintAllPosts();
                        Console.WriteLine("Enter post id.");
                        var id = Console.ReadLine();
                        Console.WriteLine("Enter comment content.");
                        var text = Console.ReadLine();
                        Blog.CreateComment(text, int.Parse(id));
                        PrintAllPosts();
                        break;

                    case "0":
                        Console.WriteLine("Exiting application.");
                        return;

                    default:
                        Console.WriteLine("That is an invalid command!");
                        break;
                }
            } while (answer != "0");
            Console.Read();
        }
        /// <summary>
        /// Return all blog posts. Only show public posts.
        /// </summary>
        public static void PrintAllPosts()
        {
            foreach (var post in Blog.AllPosts)
            {
                if (post.TypeOfPost == PrivatePost.Public)
                {
                    Console.WriteLine("Id: {0}", post.ID);
                    Console.WriteLine("Title: {0}", post.Title);
                    Console.WriteLine("Content: {0}", post.GetPost());
                    Console.WriteLine("Post Comments:");

                    // Find and show all comments with PostID of post.ID
                    var comments = Blog.AllComments.Where<Comment>(f => f.PostID == post.ID);
                    foreach (var comment in comments)
                    {
                        Console.WriteLine(comment.Content);
                    }

                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine("Error. This post is private.");
                }

            }
        }
    }
}
