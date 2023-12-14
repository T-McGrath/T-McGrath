using System;
using System.Collections.Generic;
using System.IO;

namespace QuizMaker
{
    class Program
    {
        private const string FILE_PATH = "C:\\Users\\Student\\workspace\\trevor-mcgrath-student-code\\module-1\\16b_File_IO_Reading\\exercise\\quiz_file.txt";
        static void Main(string[] args)
        {
            string[] lineAsList;
            string question;
            int correctAnswer = -1;
            List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
            int userAnswer = 0;
            int questionCount = 0;
            using (StreamReader fileInput = new StreamReader(FILE_PATH))
            {
                while (!fileInput.EndOfStream)
                {
                    List<string> answerChoices = new List<string>();
                    lineAsList = fileInput.ReadLine().Split('|');
                    question = lineAsList[0];
                    // Answers start at index 1 (the question is index 0).
                    for (int i = 1; i < lineAsList.Length; i++)
                    {
                        if (lineAsList[i].Contains("*"))
                        {
                            answerChoices.Add($"{i}. {lineAsList[i].Substring(0, lineAsList[i].Length - 1)}");
                            correctAnswer = i;
                        }
                        else
                        {
                            answerChoices.Add($"{i}. {lineAsList[i]}");
                        }
                    }
                    quizQuestions.Add(new QuizQuestion(question, answerChoices, correctAnswer));
                }
            }
            foreach (QuizQuestion q in quizQuestions)
            {
                Console.WriteLine(q.Question);
                foreach(string answer in q.AnswerChoices)
                {
                    Console.WriteLine(answer);
                }
                Console.WriteLine("Type the number of the correct answer: ");
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out userAnswer))
                    {
                        Console.WriteLine("Please type the numeric version of the answer number.");
                    }
                } while (userAnswer == 0);
                
                if (userAnswer == q.CorrectAnswer)
                {
                    Console.WriteLine("Nice job!\n");
                }
                else
                {
                    Console.WriteLine($"Incorrect. The answer was {q.CorrectAnswer}.\n");
                }
                questionCount++;
                if (questionCount == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Do you want to try another question? Type Y or N");
                }

                string userResponse = Console.ReadLine().ToUpper();
                if (userResponse == "Y")
                {
                    Console.WriteLine();
                    continue;
                }
                else if (userResponse == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You did not type Y or N.");
                    break;
                }
            }
            Console.WriteLine("Hope you had fun!");
        }
    }
}
