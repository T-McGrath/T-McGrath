using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES & DATA TYPES */

            /*
		    1. Create a variable to hold an int and call it numberOfExercises.            
			Then set it to 26.
		    */
            //one line of comments
            //int myNumber;
            //Console.WriteLine(myNumber);
            int numberOfExercises;
            numberOfExercises = 26;

            Console.WriteLine(numberOfExercises);

            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */
            double half=(1-0.5);
            //double half = 0.5;


            Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */

            string name = "TechElevator";

            Console.WriteLine(name);

            /*
            4. Create a variable called seasonsOfFirefly and set it to 1.
            */
            int seasonsOfFirefly = 1;

            Console.WriteLine(seasonsOfFirefly);

            /*
            5. Create a variable called myFavoriteLanguage and set it to "C#".
            */
            string myFavoriteLanguage = "C#";

            Console.WriteLine(myFavoriteLanguage);

            /*
            6. Create a variable called pi and set it to 3.1416.
            */

            double pi = 3.1416;

            Console.WriteLine(pi);

            /*
            7. Create and set a variable that holds your name.
            */
            string myName = "Luke";
            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */
            int numberOfButtons = 4;
            Console.WriteLine(numberOfButtons);


            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */
            int batteryPercent = 90;

            /* EXPRESSIONS */

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int x = 121 - 27;
            Console.WriteLine(x);
            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            double question11 = 12.3 + 32.1;
            Console.WriteLine(question11);
            decimal question11A = 12.3M + 32.1M;
            Console.WriteLine(question11A);

            /*
            12. Create a string that holds your full name.
            */
            string myFullName = "Isaac Meister";
            Console.WriteLine(myFullName);
            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string q13 = "Hello, " + myFullName;
            Console.WriteLine(q13);

            /*
            14. Add a " Esquire" onto the end of your full name and save it back to
            the same variable.
            */
            myFullName = myFullName + " Esquire";
            Console.WriteLine(myFullName);
            /*
            15. Now do the same as exercise 14, but use the += operator.
            */

            myFullName += " Esquire";
            Console.WriteLine(myFullName);
            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */

            string movieName = "Saw";
            movieName += " 2";
            Console.WriteLine(movieName);

            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */
            int numberValue = 0;
            movieName += numberValue;
            Console.WriteLine(movieName);
            /*
            18. What is 4.4 divided by 2.2?
            */
            double result = 4.4 / 2.2;
            decimal result1 = 4.4M / 2.2M;

            /*
            19. What is 5.4 divided by 2?
            */

            double number = 5.4 / 2;
            Console.WriteLine(number);

            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */
            int five = 5;
            int two = 2;
            int resultAgain = five / two;
            //int resultAgain = Math.Round(five / two);
            Console.WriteLine(resultAgain);
            /*
            21. What is 5.0 divided by 2?
            */
            decimal resuktAgainAgain = 5.0M / two;
            Console.WriteLine(resuktAgainAgain);
            /*
            22. What is 66.6 divided by 100? Is the answer you get right or wrong?
            */
            double answer = 66.6 / 100;
            Console.WriteLine(answer);
            decimal betterAnswer = 66.6M / 100;
            Console.WriteLine(betterAnswer);
            /*
            23. If I divide 5 by 2, what's my remainder?
            */
            int remainder = 5 % 2;
            /*
            24. Create two variables: 3 and 1,000,000,000 and multiple them together.
                What is the result?
            */
            int three = 3;
            int tooMany = 1000000000;
            Console.WriteLine(three * tooMany);
            long tooTooMany = (long)three* tooMany;
            Console.WriteLine(tooTooMany);
            /*
            25. Create a variable that holds a boolean called isDoneWithExercises and
            set it to false.
            */
            bool isDoneWithExercises = false;
            /*
            26. Now set isDoneWithExercise to true.
            */
            isDoneWithExercises = true;
        }
    }
}
