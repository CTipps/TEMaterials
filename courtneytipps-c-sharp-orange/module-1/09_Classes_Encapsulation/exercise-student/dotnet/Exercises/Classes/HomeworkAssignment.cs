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
                if ((double)EarnedMarks / PossibleMarks >= .9)
                {
                    return "A";
                }
                else if ((double)EarnedMarks / PossibleMarks >= .8)
                {
                    return "B";
                }
                else if ((double)EarnedMarks / PossibleMarks >= .7)
                {
                    return "C";
                }
                else if ((double)EarnedMarks / PossibleMarks >= .6)
                {
                    return "D";
                }
                else { return "F"; }
            }
        }

        public HomeworkAssignment(int possibleMarks, string submitterName)
        {
            PossibleMarks = possibleMarks;
            SubmitterName = submitterName;
        }
    }
}
