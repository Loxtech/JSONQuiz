using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSONQuiz
{
    class Program
    {
        static void Main(string [] args)
        {
            Quiz quiz = new Quiz();
            var question = quiz.GetQuestion();
            DisplayQuestion(question);

            if (ValidateUserAnswer(out int userNumber))
            {
                if (question.Answers[userNumber - 1].IsCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Svaret er korekt!");
                    Console.ResetColor();
                    Console.WriteLine($"\n{question.Info}"); 
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Svaret er forkert.");
                    Console.ResetColor();
                }
            }
            Console.ReadLine();
        
        }

        private static bool ValidateUserAnswer(out int userNumber)
        {
            bool correctKey = false;
            int digit = 0;
            while (!correctKey)
            {
                string userAnswer = Console.ReadLine();
                bool isDigit = int.TryParse(userAnswer, out digit);
                if (isDigit)
                {
                    correctKey = digit < 1 || digit > 3 ? false : true;
                }

                if (!correctKey)
                {
                    Console.WriteLine("Den indtastet værdi er ugyldig. Indtast venligst 1, 2 eller 3");
                }
            }
            userNumber = digit;
            return correctKey;
        }

        static void DisplayQuestion(Questions question)
        {
            Console.WriteLine($"\n{question.Question}\n");
            foreach (var answer in question.Answers)
            {
                Console.WriteLine($"{answer.Id}. {answer.Text}");
            }
            Console.WriteLine("\nIndtast nummeret på det svar du mener er rigtigt: 1, 2 eller 3");
        }


    }
}