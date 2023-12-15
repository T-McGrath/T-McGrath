namespace Exercises.Classes
{
    public class HomeworkAssignment
    {
        public int EarnedMarks { get; set; }
        public int PossibleMarks { get; private set; }
        public string SubmitterName { get; private set; }

        public string LetterGrade
        {
            get
            {
                double percent = (double)EarnedMarks / PossibleMarks;
                if (percent >= 0.90)
                {
                    return "A";
                }
                else if (percent >= 0.80 && percent <= 0.89)
                {
                    return "B";
                }
                else if (percent >= 0.70 && percent <= 0.79)
                {
                    return "C";
                }
                else if (percent >= 0.60 && percent <= 0.69)
                {
                    return "D";
                }
                else
                {
                    return "F";
                }
            }
        }

        public HomeworkAssignment(int possibleMarks, string submitterName)
        {
            PossibleMarks = possibleMarks;
            SubmitterName = submitterName;
        }



    }
}
