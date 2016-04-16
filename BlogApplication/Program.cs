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
            Blog.CreatePost("Hello World!", "Hello, World! This is a blog post!", "public");
            Blog.CreatePost("Second Post", "This is another blog post.", "public");
            Blog.CreatePost("Lorem Ipsum", "Lorem ipsum is placeholder text commonly used during design and development phase of a website.", "public");

            Console.WriteLine("Welcome to Blog Application!");
            Console.WriteLine("Please choose one of the options.");
            Console.WriteLine("1. View all posts.");
            Console.WriteLine("2. Create a new post.");
            Console.WriteLine("3. Create a comment.");
            Console.WriteLine("0. Exit program.");

            var answer = Console.ReadLine();

            switch(answer)
            {
                case "1":
                    Console.WriteLine("Printing out all posts.");
                    Post.PrintAll();
                    break;

                case "2":
                    Console.WriteLine("Enter post title.");
                    var title = Console.ReadLine();
                    Console.WriteLine("Enter post content.");
                    var content = Console.ReadLine();
                    Console.WriteLine("Enter post status. Private or Public.");
                    var status = Console.ReadLine();
                    var post = Blog.CreatePost(title, content, status);
                    Post.PrintAll();
                    break;

                case "3":
                    Post.PrintAll();
                    Console.WriteLine("Enter post id.");
                    var id = Console.ReadLine();
                    Console.WriteLine("Enter comment content.");
                    var text = Console.ReadLine();
                    Blog.CreateComment(text, int.Parse(id));
                    Post.PrintAll();
                    break;

                case "0":
                    Console.WriteLine("Exiting application.");
                    return;

                default:
                    Console.WriteLine("That is an invalid command!");
                    break;
            }

            Console.Read();
        }
    }
}
