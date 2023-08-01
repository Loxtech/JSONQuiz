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
            Console.WriteLine("Velkommen til JSONQuiz, Vælg venligst en af følgende muligheder \n1: Quiz om vandforbrug. \n2: Quiz om c#.");
            if (ValidateUserChoice(out int choice))
            {
                Console.Clear();
                Quiz quiz = new Quiz(choice);
                double points = 0;
                int amountOfQuestions = quiz.AllQuestions.Count;

                for (int i = 0; i < amountOfQuestions; i++)
                {
                    Console.WriteLine($"Spørgsmål {i+1} / {amountOfQuestions}");
                    var question = quiz.GetQuestion(i);
                    DisplayQuestion(question);
                    if (ValidateUserAnswer(out int userNumber))
                    {
                        if (question.Answers[userNumber - 1].IsCorrect)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Svaret er korekt!");
                            Console.ResetColor();
                            Console.WriteLine($"\n{question.Info}");
                            points++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Svaret er forkert.");
                            Console.ResetColor();
                        }
                    }
                    Console.WriteLine("\nTryk en tilfældig kan for at fortsætte");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.WriteLine($"Du havde: {points} ud af 6 rigtige det svare til {Math.Round(points / amountOfQuestions * 100, 2)}%");
            }
        }
        private static bool ValidateUserChoice(out int userNumber)
        {
            bool correctKey = false;
            int digit = 0;
            while (!correctKey)
            {
                string userAnswer = Console.ReadLine();
                bool isDigit = int.TryParse(userAnswer, out digit);
                if (isDigit)
                {
                    correctKey = digit < 1 || digit > 2 ? false : true;
                }

                if (!correctKey)
                {
                    Console.WriteLine("Den indtastet værdi er ugyldig. Indtast venligst 1 eller 2");
                }
            }
            userNumber = digit;
            return correctKey;
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