using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebApplication.Models.Dto
{
    public class CreateQuestionDto
    {
        public string QuestionContent { get; set; }

        public int CategoryId { get; set; }
    }
}
