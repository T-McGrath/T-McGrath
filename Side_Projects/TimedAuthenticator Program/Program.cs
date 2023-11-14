using System.Security.Cryptography;

namespace TimedAuthenticator
{
    /* The program is like an authenticator key. It will create a random number 
     * whose length is chosen by the user. The number will reset 10 seconds from the
     * time you retrieved your last new authentication number. The previous date
     * and time you retrieved that number is saved in a txt file within the 
     * TimeAuthenticator folder.
     */
    
    internal class Program
    {
        private static string prevDateTimeFilePath = "C:\\Users\\Student\\workspace\\trevor-mcgrath-student-code\\side_projects\\TimedAuthenticator\\prevDateTime.txt";
        private static string prevAuthNumFilePath = "C:\\Users\\Student\\workspace\\trevor-mcgrath-student-code\\side_projects\\TimedAuthenticator\\prevAuthNum.txt";
        private static string authenticationNumber = "0";
        private static int resetTimer = 10; // in seconds

        static void Main(string[] args)
        {
            Console.WriteLine("Do you want the newest authentication number? Type Y or N then hit Enter.");
            string userInput = Console.ReadLine().ToUpper();
            while (userInput != "N")
            {
                if (userInput == "Y" & shouldAuthNumChange())
                {
                    authenticationNumber = generateNumber(DecideAuthNumLength());
                    Console.WriteLine("The new authentication number is: " + authenticationNumber);
                    SaveCurDateTimeToFile();
                    SaveCurAuthNumberToFile();
                }
                else if (userInput == "Y" & !shouldAuthNumChange())
                {
                    if (authenticationNumber == "0") // Use auth num from last run of program if not enough time has passed to create a new one.
                    {
                        Console.WriteLine("Current authentication number: " + File.ReadAllText(Program.prevAuthNumFilePath));
                    }
                    else
                    {
                        Console.WriteLine("Current authentication number: " + authenticationNumber);
                    }
                }
                else
                {
                    Console.WriteLine("You did not type a Y or N. Please read the prompt carefully.");
                }
                Console.WriteLine("Do you want the newest authentication number? Type Y or N then hit Enter.");
                userInput = Console.ReadLine().ToUpper();
            }
            Console.WriteLine("Go be awesome today!");
        }

        // User determines the length of the authentication number.       
        public static int DecideAuthNumLength()
        {
            Console.WriteLine("Type the number of digits you'd like for your authentication number. Pick a whole number from 5 through 15.");
            int userNum = 0;
            while (userNum == 0)
            {
                if (int.TryParse(Console.ReadLine(), out userNum))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Please type a whole number from 5 to 15, inclusive and then hit enter.");
                }
            }
            return userNum;                      
        }
        
        // Creates an authentication number of given length.
        public static string generateNumber(int numLength)
        {
            string authNumAsString = "";
            for(int i = 0; i < numLength; i++)
            {
                authNumAsString += RandomNumberGenerator.GetInt32(10); // Chooses a number from 0-9 (must be single digit)
            }

            return authNumAsString;
        }
        
        // Save the current DateTime object to a txt file.
        public static void SaveCurDateTimeToFile()
        {
            using (StreamWriter writer = new StreamWriter(Program.prevDateTimeFilePath))
            {
                writer.WriteLine(DateTime.Now);
            }
        }

        // Save the current authentication number to a txt file (this is not secure...I know)
        public static void SaveCurAuthNumberToFile()
        {
            using (StreamWriter writer = new StreamWriter(Program.prevAuthNumFilePath))
            {
                writer.WriteLine(authenticationNumber);
            }
        }

        // Decide if a new authentication number is necessary.
        public static bool shouldAuthNumChange()
        {
            DateTime curDateTime = DateTime.Now;
            bool doesTxtFileExist = File.Exists(Program.prevDateTimeFilePath);
            if (doesTxtFileExist)
            {
                string prevDateTimeString = File.ReadAllText(Program.prevDateTimeFilePath);
                DateTime prevDateTime = DateTime.Parse(prevDateTimeString);
                TimeSpan diffInDateTimes = curDateTime.Subtract(prevDateTime);
                bool isDiffYearDayHourMin = diffInDateTimes.Days != 0 || diffInDateTimes.Hours != 0 || diffInDateTimes.Minutes != 0;
                if (isDiffYearDayHourMin || diffInDateTimes.Seconds > resetTimer)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}