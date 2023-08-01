using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSONQuiz
{
    public class Quiz
    {
        
        public Quiz(int choice)
        {
            CreateQuestions(choice);
        }
        public List<Questions> AllQuestions { get; set; }

        public void CreateQuestions(int choice)
        {
            if (choice == 1)
            {
                var path = Directory.GetCurrentDirectory() + "\\questions.json";
                var content = File.ReadAllText(path, Encoding.GetEncoding("iso-8859-1"));
                AllQuestions = JsonConvert.DeserializeObject<List<Questions>>(content);
            }
            else if (choice == 2)
            {
                var path = Directory.GetCurrentDirectory() + "\\questions2.json";
                var content = File.ReadAllText(path, Encoding.GetEncoding("iso-8859-1"));
                AllQuestions = JsonConvert.DeserializeObject<List<Questions>>(content);
            }
            else
            {
                Console.WriteLine("Forkert input");
            }
        }
           

        public Questions GetQuestion(int number)
        {
            var question = AllQuestions.ToList();
            //var number = Randomizer.GetRandomNumber(6);
            return question[number];
        }
    }

    

}
