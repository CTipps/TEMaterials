using System;
using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
        Given two lists of Integers, interleave them beginning with the first element in the first list followed
        by the first element of the second. Continue interleaving the elements until all elements have been interwoven.
        Return the new list. If the lists are of unequal lengths, simply attach the remaining elements of the longer
        list to the new list before returning it.
        DIFFICULTY: HARD
        InterleaveLists( [1, 2, 3], [4, 5, 6] )  ->  [1, 4, 2, 5, 3, 6]
        */
        public List<int> InterleaveLists(List<int> listOne, List<int> listTwo)
        {
            int i = 0;
            List<int> merge = new List<int>();
            if (listOne.Count > listTwo.Count)
            {
                for (i = 0; i < listTwo.Count; i++)
                {
                    merge.Add(listOne[i]);
                    merge.Add(listTwo[i]);
                }
                listOne.RemoveRange(0, listTwo.Count);
                merge.AddRange(listOne);

            }
            else if (listTwo.Count > listOne.Count)
            {
                for (i = 0; i < listOne.Count; i++)
                {
                    merge.Add(listOne[i]);
                    merge.Add(listTwo[i]);
                }
                listTwo.RemoveRange(0, listOne.Count);
                merge.AddRange(listTwo);
            }
            else
            {
                for (i = 0; i < listOne.Count; i++)
                {
                    merge.Add(listOne[i]);
                    merge.Add(listTwo[i]);
                }
            }
            return merge;
        }
    }
}
