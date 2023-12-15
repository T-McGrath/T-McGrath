using System;

namespace TechElevator.Bookstore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Tech Elevator Bookstore");
            Console.WriteLine();

            // Step Three: Test the getters and setters
            Book twoCities = new Book();
            twoCities.Title = "A Tale of Two Cities";
            twoCities.Author = "Charles Dickens";
            twoCities.Price = 14.99M;
            Console.WriteLine($"Title: {twoCities.Title}, Author: {twoCities.Author}, Price: ${twoCities.Price}");
            // Step Five: Test the Book constructor

            // Step Nine: Test the ShoppingCart class

        }
    }
}
