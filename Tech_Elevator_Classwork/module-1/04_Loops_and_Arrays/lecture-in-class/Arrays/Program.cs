using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Before step 1 you get Lori's more fun version!
            //Declare an array
            string[] myPonies;
            string myFavoritePony = "Blossom";

            //initialize (create an instance)
            myPonies = new string[6];

            //fill up the elements in the array with values
            myPonies[0] = "Cotton Candy";
            myPonies[2] = "Scoops";
            myPonies[1] = "Applejack";

            myPonies[2] = "Scoops";
            myPonies[4] = "Cuddles";
            myPonies[5] = "Lavender";

            myPonies[2] = "Pinkie Pie";

            //A quick reminder since I know you are still new to coding - you can of course put elements into your array by using a variable:
           
            myPonies[5] = myFavoritePony;

            //retrieve a value out of the array by index:
            string mySecretPony = myPonies[17-15];
            int indexOfTheSecretPony = 17 - 15;
            Console.WriteLine("My Secret Pony Is: " + myPonies[indexOfTheSecretPony]);

            Console.WriteLine();

            //Declare and create an instance of an array with the elements filled in at instantiation:
            string[] myPetNames = new string[] { "Foxy", "Lily", "Luna", "Snowflake" };

            //string thisWillBreak = myPetNames[3];
            //myPetNames[8] = "This Will Also Break";

            int[] myNumbers = new int[6] { 45, 78, 100, 2, 1, 99 };

            //Do you need to know how big your array is? The implementation comes with an easy way to do that:
            int myStableHoldsThisManyHorses = myPonies.Length;

            int theHighestIndexInMyStable = myPonies.Length - 1;

            Console.WriteLine("The last pony on the right is: " + myPonies[theHighestIndexInMyStable]);
            Console.WriteLine("The last pony on the right is: " + myPonies[myPonies.Length - 1]);

            //Remember, an array is fixed length - you can't add any more elements. You also can't delete elements (though you can replace them with null values)
            // If you need to add more elements to an array, you can't do that so you will have to create a bigger array and copy your elements over to that one.

            //a real-world example: a dropdown list on a webpage might be a use for an array. Or any text inputs that you take in on a form could be inserted into an array.

            //loop through the elements of an array BY INDEX and do something with the elements
            for (int i = 0; i < myPetNames.Length; i++)
            {
                Console.WriteLine($"My Pet at index {i} is: {myPetNames[i]}");
            }

            Console.WriteLine("Hello World");

            //1. Creating an array of integers
            int[] quizScores = new int[4];
            quizScores[0] = 100;
            quizScores[1] = 80;
            quizScores[2] = 85;
            quizScores[3] = 90;

            //2. Creating an array of strings
            string[] names = new string[] { "Josh", "David", "Craig", "Casey" };

            //3. Create an array of characters that hold "Tech Elevator"
            char[] letters = { 'T', 'e', 'c', 'h', ' ', 'E', 'l', 'e', 'v', 'a', 't', 'o', 'r' };

            //4. Print out the first item in each array
            Console.WriteLine("First quiz score is " + quizScores[0]);
            Console.WriteLine("First name is " + names[0]);
            Console.WriteLine("First letter is " + letters[0]);

            //5. Print out the 3rd item in each array
            Console.WriteLine("3rd quiz score is " + quizScores[2]);
            Console.WriteLine("3rd name is " + names[2]);
            Console.WriteLine("3rd letter is " + letters[2]);

            //6. Get the length of each array
            int lengthOfQuizArray = quizScores.Length;
            Console.WriteLine("There are " + lengthOfQuizArray + " items in quiz array");

            int lengthOfNamesArray = names.Length;
            Console.WriteLine("There are " + lengthOfNamesArray + " items in names array");

            Console.WriteLine("There are " + letters.Length + " items in names array");

            //7. Get the last index
            //Console.WriteLine("The last index is " + quizScores.Length - 1); doesn't compile why??
            Console.WriteLine("The last index is " + (quizScores.Length - 1));

            //8. Update the last item in each array
            quizScores[quizScores.Length - 1] = 100;
            names[names.Length - 1] = "Josh";

        }
    }
}
