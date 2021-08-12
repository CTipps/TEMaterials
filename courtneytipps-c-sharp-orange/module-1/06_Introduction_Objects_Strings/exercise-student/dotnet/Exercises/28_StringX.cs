namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a string, return a version where all the "x" have been removed. Except an "x" at the very start or end
        should not be removed.
        StringX("xxHxix") → "xHix"
        StringX("abxxxcd") → "abcd"
        StringX("xabxxxcdx") → "xabcdx"
        */
        public string StringX(string str)
        {
            string xGonnaGiveIt = "";
            string start = "";
            string end = "";
            if (str.Length > 0)
            {
                start = str.Substring(0, 1);
            }
            if (str.Length == 2)
            {
                end = str.Substring(str.Length - 1);
            }
            if (str.Length > 2)
            {
                end = str.Substring(str.Length - 1, 1);
                for (int i = 1; i < str.Length - 1; i++)
                {
                    if (str.Substring(i, 1) == "x")
                    {
                        continue;
                    }
                    else
                    {
                        xGonnaGiveIt = xGonnaGiveIt + str.Substring(i, 1);
                        {
                        }

                    }
                }
                xGonnaGiveIt = start + xGonnaGiveIt + end;
            }
            else
            {
                xGonnaGiveIt = start + xGonnaGiveIt + end;
            }
            return xGonnaGiveIt;
        }
    }
}
