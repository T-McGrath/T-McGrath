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
            string name = "Foxy";
            string otherName = "foxy";
            //these two lines on 16 and 17 do exactly the same thing
            bool isEqual = name == otherName;
            bool isAlsoEqual = name.Equals(otherName);


            bool isSortOfEqual = name.Equals(otherName, StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine("Welcome to the Discount Calculator");

            // Prompt the user for a discount amount
            // The answer needs to be saved as a decimal
            Console.Write("Enter the discount amount (w/out percentage): ");
            string userDiscountInput = Console.ReadLine();
            decimal userDiscount = decimal.Parse(userDiscountInput);




            // Prompt the user for a series of prices
            Console.Write("Please provide a series of prices (space separated): ");
            // string myFullName = "Foxy Somerville";
            // myFullName.split(' ');
            string userPrices = Console.ReadLine();
            string[] listOfPrices = userPrices.Split(' ');
            decimal totalPrice;
            totalPrice = 0M;
            decimal[] discountListOfPrices = new decimal[listOfPrices.Length];

            for(int i = 0; i < listOfPrices.Length; i++)
            {
                decimal discountedPrice = decimal.Parse(listOfPrices[i])*(1-(userDiscount/100));
                discountListOfPrices[i] = discountedPrice;
                //Console.WriteLine("Your discounted price is " + Math.Round(discountListOfPrices[i], 2));
                Console.WriteLine("Your discounted price is " + discountListOfPrices[i].ToString("C"));
                totalPrice += discountListOfPrices[i];
            }


            Console.WriteLine("Your total price is = " + totalPrice);
            







        }
    }
}
