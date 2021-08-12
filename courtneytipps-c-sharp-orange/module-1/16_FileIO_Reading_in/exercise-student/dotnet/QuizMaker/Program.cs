using System;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            QuizQuestions method = new QuizQuestions();
            method.GetQuiz();
            method.QuizPlayer();
        }
    }
}
