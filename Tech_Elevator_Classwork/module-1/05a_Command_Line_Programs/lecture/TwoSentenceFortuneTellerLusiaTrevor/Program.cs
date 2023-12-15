namespace TwoSentenceFortuneTellerLusiaTrevor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstFortuneIndex;
            int secondFortuneIndex;
            string[] firstFortuneArray = new string[7];
            firstFortuneArray[0] = "Ha ha (sarcastically), if your input is this annoying, your fortune is death. The end.";
            firstFortuneArray[1] = "Your next lunch will be sus."; 
            firstFortuneArray[2] = "On your 41st birthday, none of your friends will remember.";
            firstFortuneArray[3] = "In five years, you will be audited by the IRS."; 
            firstFortuneArray[4] = "If you take a roadtrip in the next two weeks, you will uncontrollably pee your pants.";
            firstFortuneArray[5] = "The next time you see a cat, it will attack you and your family.";
            firstFortuneArray[6] = "You woke up today, yay!";

            string[] secondFortuneArray = new string[5];
            secondFortuneArray[0] = "And you will regret it.";
            secondFortuneArray[1] = "And people will judge you.";
            secondFortuneArray[2] = "And you will lose exactly three pieces of hair.";
            secondFortuneArray[3] = "And you will step on a blue Lego.";
            secondFortuneArray[4] = "Either your English is not great or you're an annoying turd.";

            Console.WriteLine("Welcome to the Two Sentence UNFortune Teller!");
            Console.WriteLine("Enter your age:");
            int userAge = int.Parse(Console.ReadLine());
            
            if (userAge < 1)
            {
                firstFortuneIndex = 0;
                Console.WriteLine(firstFortuneArray[firstFortuneIndex]);
                return;
            }
            Console.WriteLine("In what season were you born?");
            string userSeason = Console.ReadLine();
                        

            if (userAge >=1 && userAge <= 20)
            {
                firstFortuneIndex = 1;
            }
            else if (userAge >= 21 && userAge <= 40)
            {
                firstFortuneIndex = 2;
            }
            else if (userAge >= 41 && userAge <= 60)
            {
                firstFortuneIndex = 3;
            }
            else if (userAge >= 61 && userAge <= 80)
            {
                firstFortuneIndex = 4;
            }
            else if (userAge >= 81 && userAge <= 100)
            {
                firstFortuneIndex = 5;
            }
            else
            {
                firstFortuneIndex = 6;
            }

            Console.WriteLine(firstFortuneArray[firstFortuneIndex]); // First fortune


            if(userSeason.ToLower() == "fall" || userSeason.ToLower() == "autumn")
            {
                secondFortuneIndex = 0;
            }
            else if (userSeason.ToLower() == "winter")
            {
                secondFortuneIndex = 1;
            }
            else if (userSeason.ToLower() == "spring")
            {
                secondFortuneIndex = 2;
            }
            else if (userSeason.ToLower() == "summer")
            {
                secondFortuneIndex = 3;
            }
            else
            {
                secondFortuneIndex = 4;
            }

            Console.WriteLine(secondFortuneArray[secondFortuneIndex]);
                        
        }
    }
}