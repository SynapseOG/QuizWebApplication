using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebApplication.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string? AnswerContentA { get; set; }

        public string? AnswerContentB { get; set; }

        public string? AnswerContentC { get; set; }

        public string? AnswerContentD { get; set; }

        public string CorrectAnswer { get; set; }

        public int QuestionId { get; set; }

        public virtual Question? Question { get; set; }
    }
}
