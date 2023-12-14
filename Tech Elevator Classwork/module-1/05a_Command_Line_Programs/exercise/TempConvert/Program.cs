using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            const double multDivNum = 1.8;
            const int addSubNum = 32;
            int userTemperature;
            Console.WriteLine("Salutaions, Benthalomew! Please enter a temperature as an integer:");
            try
            {
                userTemperature = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("You did not type an integer. Please re-run the program. \nBy the way, did you know Lori LOVES My Little Pony?");
                return;
            }

            Console.WriteLine("Now, type 'C' for celsius or 'F' for fahrenheit:");
            string userUnits = Console.ReadLine().ToUpper();
            string convertedUnits;
            int convertedTemp;
            if (userUnits == "C")
            {
                convertedTemp = (int)(userTemperature * multDivNum + addSubNum);
                convertedUnits = "F";
            }
            else if (userUnits == "F")
            {
                convertedTemp = (int)((userTemperature - addSubNum) / multDivNum);
                convertedUnits = "C";
            }
            else
            {
                Console.WriteLine("You did not type 'C' or 'F'! Please re-run the program and try again.");
                return;
            }
            Console.WriteLine(userTemperature + userUnits + " is " + convertedTemp + convertedUnits + ".");            
        }
    }
}
