namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return true if the first instance of "x" in the string is immediately followed by another "x".
        DoubleX("axxbb") → true
        DoubleX("axaxax") → false
        DoubleX("xxxxx") → true
        */
        public bool DoubleX(string str)
        {
            bool dblX = false;
            int firstX = str.IndexOf("x");
            if (firstX > str.Length - 2 || firstX == -1)
            {
                dblX = false;
            }

           else if ((str.Substring(firstX, 1) + str.Substring(firstX + 1, 1)) == "xx")
            {
                dblX = true;
            }
            else
            {
                dblX = false;
            }

            return dblX;
        }
    }
}
