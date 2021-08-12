namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return true if it ends in "ly".
        EndsLy("oddly") → true
        EndsLy("y") → false
        EndsLy("oddy") → false
        */
        public bool EndsLy(string str)
        { if (str.Length < 2)
            {
                return false;
            }
            string end = str.Substring(str.Length - 2).ToLower();
            if (end == "ly")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
