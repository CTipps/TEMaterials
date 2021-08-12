namespace Exercises
{
    public partial class Exercises
    {
        /*
        We'll say that a number is "teen" if it is in the range 13..19 inclusive. Given 3 int values,
        return true if 1 or more of them are teen.
        HasTeen(13, 20, 10) → true
        HasTeen(20, 19, 10) → true
        HasTeen(20, 10, 13) → true
        */
        public bool HasTeen(int a, int b, int c)
        { if (a <= 19 && a >= 13)
            {
                return true;
            } else if (b <= 19 && b >= 13)
            {
                return true;
            }
            else if (c <= 19 && c >= 13)
            {
                return true;
            } else
            {
                return false;
            }


        }
    }
}
