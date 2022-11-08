using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebApplication.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string? QuestionContent { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual Answer Answer { get; set; }
    }
}
