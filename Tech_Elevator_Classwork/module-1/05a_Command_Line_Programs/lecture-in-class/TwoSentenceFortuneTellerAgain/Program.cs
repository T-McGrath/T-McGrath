namespace TwoSentenceFortuneTellerAgain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to two sentence fortune, please wait while I center myself");
            Center();
            Console.WriteLine("Please enter a number between 1 and 100");
            string number = Console.ReadLine();
            bool parsed = int.TryParse(number, out int result);
            if (!parsed || result > 100)
            {
                Console.WriteLine("You didn't follow instructions but I can handle that, I am one with the universe");
            }

            Console.WriteLine();
            Console.WriteLine("Please tell me what your favorite food is");
            string food = Console.ReadLine().ToLower();
            char firstletter = food[0];
            string inattentiveText = "Due to your natural inattentiveness you will fall into an open manhole cover";
            var secondSentence = firstletter switch
            {
                'a' or 'b' or 'c' or 'd' or 'e' or 'f' => "The next day you will sadly perish",
                'g' or 'h' or 'i' or 'j' or 'k' or 'l' => "And you will live hapily ever after",
                'm' or 'n' or 'o' or 'p' or 'q' or 'r' => "And wow a week later nasa will invite you into their astronaut program super cool",
                's' or 't' or 'u' or 'v' or 'w' or 'x' or 'y' or 'z' => "Aliens will then invade the earth and you will lead the resistance",
                _ => inattentiveText,
            };
            if (secondSentence == inattentiveText)
            {
                if (result == 0 || result > 100)
                {
                    Console.WriteLine("You're testing my serenity for sure");
                }
                else
                {
                    Console.WriteLine("I have never heard of that food, but fear not I will listen to the ebb and flow of space and time");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Please wait while I commune with the spirits");
            Center();
            string ouchresult = "You will find a penny on the street and while trying to pick it up injure your lower back";
            string firstSentence = "";
            if (result == 0)
            {
                firstSentence = ouchresult;
            }
            else if (result > 0 && result < 26)
            {
                firstSentence = "You will find true love";
            }
            else if (result > 25 && result < 51)
            {
                firstSentence = "You will enjoy a beautiful day at the park, the birds will sing and all will feel wonderful";
            }
            else if (result > 50 && result < 76)
            {
                firstSentence = "A long lost friend will come to visit you";
            }
            else if (result > 75 && result < 101)
            {
                firstSentence = "You will see five different owls in one day this is a portent of things to come";
            }
            else
            {
                firstSentence = ouchresult;
            }

            Console.WriteLine();
            Console.WriteLine(firstSentence);
            Console.WriteLine();
            Center();
            Console.WriteLine();
            Console.WriteLine(secondSentence);
            Console.WriteLine();
            Center();
            Console.WriteLine();
            Console.WriteLine("THANK YOU FOR USING TWO SENTENCE FORTUNE HAVE A GREAT DAY!!!!!!!!");
        }

        private static void Center()
        {
            Thread.Sleep(500);
            Console.Write(". ");
            Thread.Sleep(500);
            Console.Write(". ");
            Thread.Sleep(500);
            Console.Write(". ");
            Thread.Sleep(500);
            Console.Write(". ");
            Thread.Sleep(500);
            Console.Write(".");
            Console.WriteLine();
        }
    }
}
