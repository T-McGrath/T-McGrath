using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace McWordle
{
    public class Wordle
    {
        public List<string> FiveLetterWords { get; set; } = new List<string>() { "RADAR" };

        // The two commands below aren't working for some reason...
        //FiveLetterWords.Add("STUFF");
        //FiveLetterWords.Add("THINGS");

        public int NumberOfLetters { get; private set; } = 5;
        public int NumberOfTurns { get; private set; } = 6;
        public int TurnsRemaining { get; private set; }
        public string MysteryWord { get; private set; } = "";
        public string[] GameBoard { get; set; }
        public string UserGuess { get; private set; } = "";

        // Get everything going
        public void StartGame()
        {
            bool shouldPlay = DoesUserWantToPlay();
            if (shouldPlay)
            {
                NumberOfTurns = ChooseNumTurns();
                MysteryWord = ChooseWordFromList(NumberOfLetters);
                GiveDirections();
                for (int i = 0; i < NumberOfTurns; i++)
                {
                    TakeTurn(); // Updates UserGuess
                    Console.WriteLine(UpdateBoard(UserGuess, MysteryWord)); // Updates GameBoard
                    TurnsRemaining--;

                    if (DidWin())
                    {
                        Console.WriteLine(EndGame());
                        return;
                    }
                    //Console.WriteLine(GameBoard);
                }
                Console.WriteLine(EndGame());
                return;
            }
            else
            {
                Console.WriteLine("You're a fantastic human being. Have a spectacular day!");
            }
        }

        public string ChooseWordFromList(int numLet)
        {
            int RandIndex = 0; // May need to alter this in the future.
            Random rand = new Random();
            if (numLet == 5)
            {
                RandIndex = rand.Next(FiveLetterWords.Count);
            }
            return FiveLetterWords[RandIndex];
        }


        public bool DoesUserWantToPlay()
        {
            string userPlayYN = "";
            while (userPlayYN != "Y" && userPlayYN != "N")
            {
                Console.WriteLine("Do you want to play Wordle? Type Y or N then hit Enter.");
                userPlayYN = Console.ReadLine().ToUpper();
            }
            if (userPlayYN == "Y")
            {
                return true;
            }
            return false;
        }

        public int ChooseNumTurns()
        {
            int userNumTurn = 0;
            Console.WriteLine("You get to choose how many chances you get to guess the mystery word!");
            while (userNumTurn <= 0)
            {
                Console.WriteLine("Type an integer greater than 0 then hit Enter.");
                try
                {
                    userNumTurn = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("You did not type an integer. Please try again.");
                }
            }
            return userNumTurn;
        }

        public void GiveDirections()
        {
            Console.WriteLine($"Try to guess the {NumberOfLetters}-letter word in {NumberOfTurns} tries.\nGood luck!");
        }


        public void TakeTurn()
        {
            Console.WriteLine(TurnsRemaining == 1 ? $"You have {TurnsRemaining} try remaining." : $"You have {TurnsRemaining} tries remaining.");
            while (true)
            {
                Console.WriteLine($"Guess a {NumberOfLetters}-letter word.");
                UserGuess = Console.ReadLine().ToUpper();
                // Make sure the guess is only letters. 
                if (!UserGuess.All(Char.IsLetter))
                {
                    Console.WriteLine("Your guess must not include symbols or spaces...only letters.");
                    continue;
                }
                if (UserGuess.Length != NumberOfLetters)
                {
                    Console.WriteLine($"Your guess must be {NumberOfLetters} letters long.");
                    continue;
                }
                break;
            }
        }

        public void MakeEmptyGameBoard()
        {
            for (int i = 0; i < NumberOfLetters; i++)
            {
                GameBoard[i] = "_";
            }
        }

        // Do this after the user makes a guess
        public string UpdateBoard(string userGuess, string mysteryWord)
        {
            MakeEmptyGameBoard();
            string tempUserGuess = userGuess;
            string tempMysteryWord = mysteryWord;

            // First, find all matching letters and remove them from both the mystery word AND
            // the user's guess so they don't get counted for more than one thing.
            for (int i = 0; i < userGuess.Length; i++)
            {
                // Using a filler character so the strings are always the same length as the original. 
                // I need the indexes to match where in the GameBoard I want to add something.
                if (tempUserGuess[i] == tempMysteryWord[i])
                {
                    GameBoard[i] = "*";
                    if (i == userGuess.Length - 1)
                    {
                        tempUserGuess = tempUserGuess.Substring(0, i) + "!";
                        tempMysteryWord = tempMysteryWord.Substring(0, i) + "?";
                    }
                    else
                    {
                        tempUserGuess = tempUserGuess.Substring(0, i) + "!" + tempUserGuess.Substring(i + 1);
                        tempMysteryWord = tempMysteryWord.Substring(0, i) + "?" + tempMysteryWord.Substring(i + 1);
                    }
                }
            }

            // Second, check for letters from the guess that are IN the mystery word, but not in the right spot.
            for (int i = 0; i < UserGuess.Length; i++)
            {
                if (tempMysteryWord.Contains(tempUserGuess[i]))
                {
                    int targetIndex = tempMysteryWord.IndexOf(tempUserGuess[i]);
                    GameBoard[i] = "#";
                    if (targetIndex == UserGuess.Length - 1)
                    {
                        tempMysteryWord = tempMysteryWord.Substring(0, targetIndex) + "?";
                    }
                    if (i == UserGuess.Length - 1)
                    {
                        tempUserGuess = tempUserGuess.Substring(0, i) + "!";
                    }
                    else
                    {
                        tempUserGuess = tempUserGuess.Substring(0, i) + "!" + tempUserGuess.Substring(i + 1);
                        tempMysteryWord = tempMysteryWord.Substring(0, targetIndex) + "?" + tempMysteryWord.Substring(targetIndex + 1);
                    }
                }
            }
            return ConvertBoardToString(GameBoard);
        }

        public string ConvertBoardToString(string[] tempGameBoardArray)
        {
            string newGameBoard = "";
            foreach (string item in tempGameBoardArray)
            {
                newGameBoard += item;
            }
            return newGameBoard;
        }

        public bool DidWin()
        {
            foreach (string item in GameBoard)
            {
                if (item != "*")
                {
                    return false;
                }
            }
            return true;
        }

        public string EndGame()
        {
            if (DidWin())
            {
                return NumberOfTurns - TurnsRemaining == 1 ? $"Holy crap! You guessed the word in {NumberOfTurns - TurnsRemaining} try!" : $"Congratulations! You guessed the word in {NumberOfTurns - TurnsRemaining} tries.";
            }
            else
            {
                return "Didn't win this time. Brush up on your vocabulary and try again!";
            }
        }

        // Write a Reset game method (maybe)




        // Constructors
        public Wordle()
        {
            TurnsRemaining = NumberOfTurns;
            GameBoard = new string[NumberOfLetters];
        }

        public Wordle(int numTurn)
        {
            NumberOfTurns = numTurn;
            TurnsRemaining = NumberOfTurns;
            GameBoard = new string[NumberOfLetters];
        }

        public Wordle(int numLet, int numTurn)
        {
            NumberOfLetters = numLet;
            NumberOfTurns = numTurn;
            TurnsRemaining = NumberOfTurns;
            GameBoard = new string[NumberOfLetters];
        }
    }
}

