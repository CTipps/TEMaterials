namespace Exercises
{
    public partial class StringExercises
    {
        /*
        Given a non-empty string like "Code" return a string like "CCoCodCode".
        StringSplosion("Code") → "
        C
        Co
        Cod
        Code"
        StringSplosion("abc") → "aababc"
        StringSplosion("ab") → "aab"
        */
        public string StringSplosion(string str)
        {
            int wordLength = str.Length;
            string splosion = "";
            for (int i = 0; i < wordLength; i++)
            {
                splosion = splosion + str.Substring(0, i + 1);
            }
            return splosion;
        }
    }
}
