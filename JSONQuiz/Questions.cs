using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONQuiz
{
    public class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Info { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
