using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizWebApplication.Data;
using QuizWebApplication.Models.Dto;

namespace QuizWebApplication.Services
{
        public interface IQuestionService
        {
            List<QuestionDto> GetQuestions(CategoryDto dto);
            int SetAnswers(IFormCollection formCollection);
        }
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public QuestionService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<QuestionDto> GetQuestions(CategoryDto dto)
        {
            var question = _dbContext.Questions.Where(x => x.CategoryId == dto.Id)
              .Include(x => x.Answer)
              .ToList();

            //if (question == null) return NotFound();


            var questionDto = _mapper.Map<List<QuestionDto>>(question);

            return questionDto;
        }

        public int SetAnswers(IFormCollection formCollection)
        {
            var list = new List<string>();
            var listOfAnswers = new List<string>();

            for (int i = 0; i < formCollection.Count; i++)
            {

                if (i == 0 || i % 2 == 0)
                    list.Add(formCollection.Keys.ElementAt(i));
                else
                    listOfAnswers.Add(formCollection.Keys.ElementAt(i));
            }

            int pointsCounter = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                var question = _dbContext.Answers.FirstOrDefault(x => x.QuestionId == Convert.ToInt32(list.ElementAt(i)));

                if (question.CorrectAnswer == listOfAnswers.ElementAt(i))
                {
                    pointsCounter++;
                }

            }
            return pointsCounter;
        }


    }
}
