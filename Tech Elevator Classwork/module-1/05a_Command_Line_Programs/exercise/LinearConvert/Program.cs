using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            const double metersToFeet = 3.2808399;
            const double feetToMeters = 0.3048;
            int userMeasurement;            
            Console.WriteLine("Hello Bencent! Please enter an integer length you would like converted: ");

            try
            {
                userMeasurement = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("You did not enter an integer. Please re-run the program and follow the directions.");
                return;
            }

            Console.WriteLine("Enter the units as \"m\" for meters or \"f\" for feet.");
            string userUnits = Console.ReadLine().ToLower();
            int convertedLength;
            string newUnits;

            if (userUnits == "m")
            {
                convertedLength = (int)(userMeasurement * metersToFeet);
                newUnits = "f";
            }
            else if (userUnits == "f")
            {
                convertedLength = (int)(userMeasurement * feetToMeters);
                newUnits = "m";
            }
            else
            {
                Console.WriteLine("You did not type an \"m\" or \"f\". Please re-run the program and carefully follow the prompts." +
                    "\nBy the way, did you know the .NET class is destined to win the ping-pong tourney?");
                return;                  
            }

            Console.WriteLine(userMeasurement + userUnits + " is equal to " + convertedLength + newUnits + ".");
        }
    }
}
