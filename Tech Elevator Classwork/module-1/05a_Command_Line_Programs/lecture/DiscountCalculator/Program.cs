using System;

namespace DiscountCalculator
{
    class Program
    {
        /// <summary>
        /// The main method is the start and end of our program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Discount Calculator");

            // Prompt the user for a discount amount
            // The answer needs to be saved as a decimal
            Console.Write("Enter the discount amount (w/out percentage): ");
            string userDiscountInput = Console.ReadLine();
            decimal userDiscount = decimal.Parse(userDiscountInput);


            // Prompt the user for a series of prices
            Console.Write("Please provide a series of prices (space separated): ");
            string userPricesInput = Console.ReadLine();
            string[] userPricesString = userPricesInput.Split(' ');

            decimal[] userDiscountPrices = new decimal[userPricesString.Length];
            decimal totalPrice = 0;
            for (int i = 0; i < userDiscountPrices.Length; i++)
            {
                
                userDiscountPrices[i] = decimal.Parse(userPricesString[i]) * (100 - userDiscount)/100;
                userDiscountPrices[i] = Math.Round(userDiscountPrices[i], 2);
                Console.WriteLine("The discounted price is: " + userDiscountPrices[i].ToString("C"));
                totalPrice += userDiscountPrices[i];
            }
            Console.WriteLine("The total price after the discount is " + totalPrice);

        }
    }
}
