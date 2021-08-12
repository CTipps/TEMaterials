using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WordSearch
{
    public class WordSearchMethods
    {
        private string filePath;
        private string searchWord;
        private string caseResponse;
        public bool caseSens = false;
        public void GetUserInput()
        {
            Console.WriteLine("What is the fully qualified name of the file that should be searched?");
            filePath = Console.ReadLine();
            Console.WriteLine("What is the search word you are looking for?");
            searchWord = Console.ReadLine();
            Console.WriteLine("Should the search be case sensitive? (Y/N)");
            caseResponse = Console.ReadLine().ToUpper();
            if (caseResponse == "Y")
            {
                caseSens = true;
            }
        }

        public void Search()
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    int i = 0;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        i++;
                        if (!caseSens)
                        {
                            if (line.ToLower().Contains(searchWord.ToLower()))
                            {
                                Console.WriteLine($"{i}) {line}");
                            }
                        } else {
                            if (line.Contains(searchWord))
                            {
                                Console.WriteLine($"{i}) {line}");
                            }
                        }
                    }
                }
            }
            catch (IOException ex) { 
                Console.WriteLine($"{ex.Message} Please try again."); }
        }

    }
   
}
