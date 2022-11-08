using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebApplication.Models.Dto
{
    public class QuestionDto
    {
        public string? QuestionContent { get; set; }

        public int CategoryId { get; set; }
        public int QuestionId { get; set; }

        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }

        public string CorrectAnswer { get; set; }

        public string SelectedAnswer { get; set; }
    }
}
