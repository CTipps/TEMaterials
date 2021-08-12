namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given 3 int values, a b c, return their sum. However, if one of the values is the same as another
         of the values, it does not count towards the sum.
         LoneSum(1, 2, 3) → 6
         LoneSum(3, 2, 3) → 2
         LoneSum(3, 3, 3) → 0
         */
        public int LoneSum(int a, int b, int c)
        {
            if (a == b && c == b)
            {
                return 0;
            }
            else if (a == b)
            {
                return c;
            }
            else if (a == c)
            {
                return b;
            }
            else if (b == c)
            {
                return a;
            }
            else
            {
                return a + b + c;
            }
        }
    }
}
