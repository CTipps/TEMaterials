using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QuizMaker
{

    public class QuizQuestions
    {
       private string[] questionArray;
        private int correctAnswer;
        private List<string> questions = new List<string>();
        private string filePath;
        private int questionCounter;
        private int questionsCorrect = 0;

        public void GetQuiz()
        {
            Console.WriteLine("Please enter fully qualified file path.");
            filePath = Console.ReadLine();
        }

        public void QuizPlayer()
        {
            int i = 0;
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        questions.Add(line);
                    }

                }

                foreach (string question in questions)
                {
                    questionCounter++;
                    questionArray = question.Split("|");
                    for (i = 0; i < questionArray.Length; i++)
                    {
                        if (questionArray[i].Contains('*'))
                        {
                            correctAnswer = i;
                        }
                        if (i < 1)
                        {
                            Console.WriteLine(questionArray[i]);
                        }
                        else
                        {
                            Console.WriteLine($"{i}. {questionArray[i].Trim('*')}");
                        }
                    }
                        Console.Write("Your answer: ");

                        int answer = int.Parse(Console.ReadLine());
                        if (answer == correctAnswer)
                        {
                            Console.WriteLine("RIGHT!");
                            questionsCorrect++;
                        }
                        else
                        {
                            Console.Write($"I'm sorry that's incorrect, it's actually: {correctAnswer}. Hit enter to continue.");
                            Console.ReadLine();
                            Console.WriteLine("");
                        }
                }
                Console.WriteLine($"You got {questionsCorrect} answer(s) correct out of {questionCounter}. Thanks for playing!");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"{ex.Message} Please try again.");
            }
        }
    }
}
