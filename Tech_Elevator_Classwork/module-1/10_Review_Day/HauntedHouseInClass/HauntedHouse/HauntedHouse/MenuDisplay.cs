using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse
{
    public class MenuDisplay
    {

        public static String Prompt(String[] options)
        {

            //default value, no option selected yet
            int selectedOption = -1;

            //keep prompting the user until we call break
            while (true)
            {

                //don't worry about try-catch for now, we will cover these later in module-1
                try
                {

                    //display the options to the user (see method below)
                    PrintOptions(options);

                    //get the input and convert it to an integer
                    selectedOption = int.Parse(Console.ReadLine());

                    //subtract 1 to get the right index
                    selectedOption--;

                    //verify the selected option is valid, if so break out of the loop
                    if (selectedOption >= 0 && selectedOption < options.Length)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    //nothing for now
                }

                Console.WriteLine("Invalid option >:0 ");
            }

            return options[selectedOption];
        }

        private static void PrintOptions(String[] options)
        {

            Console.WriteLine("Please select an option:");
            for (int i = 0; i < options.Length; i++)
            {

                int optionNum = i + 1;
                Console.WriteLine("(" + optionNum + ") " + options[i]);

            }

        }

    }

}

