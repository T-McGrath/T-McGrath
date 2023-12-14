using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public List<string> AnswerChoices { get; set; } = new List<string>();
        public int CorrectAnswer { get; set; }

        public QuizQuestion(string question, List<string> answerChoices, int correctAnswer)
        {
            Question = question;
            AnswerChoices = answerChoices;
            CorrectAnswer = correctAnswer;
        }
    }
}
