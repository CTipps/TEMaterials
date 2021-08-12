using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
        Given a List of Integers, and an int value, return true if the int value appears two or more times in
        the list.
        FoundIntTwice( [5, 7, 9, 5, 11], 5 ) -> true
        FoundIntTwice( [6, 8, 10, 11, 13], 8 -> false
        FoundIntTwice( [9, 23, 44, 2, 88, 44], 44) -> true
        */
        public bool FoundIntTwice(List<int> integerList, int intToFind)
        {
            int count = 0;
            bool dblDbl = false;
            foreach (int dbl in integerList)
            {
                if (dbl == intToFind)
                {
                    count++;
                }
                if (count > 1)
                {
                    dblDbl = true;
                }
            }
            return dblDbl;
        }
    }
}
