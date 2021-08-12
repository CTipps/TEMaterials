using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of strings, return a Dictionary<string, Boolean> where each different string is a key and value
         * is true only if that string appears 2 or more times in the array.
         *
         * WordMultiple(["a", "b", "a", "c", "b"]) → {"b": true, "c": false, "a": true}
         * WordMultiple(["c", "b", "a"]) → {"b": false, "c": false, "a": false}
         * WordMultiple(["c", "c", "c", "c"]) → {"c": true}
         *
         */
        public Dictionary<string, bool> WordMultiple(string[] words)
        {
            
            Dictionary<string, bool> multiCheck = new Dictionary<string, bool>();
            Dictionary<string, int> multiCount = new Dictionary<string, int>();
            foreach (string word in words)
            {
                multiCount[word] = 0;
            }
            foreach (string word in words)
            {
                multiCount[word] = multiCount[word] + 1;
            }
            { foreach (string word in multiCount.Keys)
                {
                    if (multiCount[word] > 1)
                    {
                        multiCheck[word] = true;
                    }
                    else
                    {
                        multiCheck[word] = false;
                    }
                }
            }
            return multiCheck;
        }
    }
}
