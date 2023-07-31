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
        public Quiz()
        {
            CreateQuestions();
        }

        public List<Questions> AllQuestions { get; set; }
        public void CreateQuestions()
        {
            var path = Directory.GetCurrentDirectory() + "\\questions.json";
            var content = File.ReadAllText(path,Encoding.GetEncoding("iso-8859-1"));
            AllQuestions = JsonConvert.DeserializeObject<List<Questions>>(content);
        }

        public Questions GetQuestion()
        {
            var question = AllQuestions.ToList();
            var number = Randomizer.GetRandomNumber(6);
            return question[number - 1];
        }
    }

    

}
