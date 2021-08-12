namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Suppose the string "yak" is unlucky. Given a string, return a version where all the "yak" are removed.
        The "yak" strings will not overlap.
        StringYak("yakpak") → "pak"
        StringYak("pakyak") → "pak"
        StringYak("yak123ya") → "123ya"
        */
        public string StringYak(string str)
        {
            string noYak = "";
            int i = 0;
            for (i = 0; i < str.Length-2 ;i++)
            {
                if (str.Substring(i,3) == "yak")
                {
                    i += 2;
                }
                else
                {
                    noYak += str.Substring(i,1);
                }
            } 
            if (i < str.Length)
            {
                noYak += str.Substring(i);
            }
            return noYak;
        }
    }
}
