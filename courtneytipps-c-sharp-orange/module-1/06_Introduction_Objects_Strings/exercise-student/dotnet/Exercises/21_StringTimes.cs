namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string and a non-negative int n, return a larger string that is n copies of the original string.
        StringTimes("Hi", 2) → "HiHi"
        StringTimes("Hi", 3) → "HiHiHi"
        StringTimes("Hi", 1) → "Hi"
        */
        public string StringTimes(string str, int n)
        {
            string added = "";
            for(int i = 0; i < n; i++)
            {
                added = added + str;
            }
            return added;
        }
    }
}
