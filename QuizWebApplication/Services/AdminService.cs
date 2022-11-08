using AutoMapper;
using QuizWebApplication.Data;
using QuizWebApplication.Models;
using QuizWebApplication.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebApplication.Services
{
    public interface IAdminService
    {
        public void CreateCategory(CategoryDto dto);
        public void DeleteCategory(int id);
        public void CreateQuestion(QuestionDto dto,int id);
    }

    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AdminService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void CreateCategory(CategoryDto dto)
        {
            var categoryDto = _mapper.Map<Category>(dto);

            var category = _dbContext.Categories.Any(r => r.Name == dto.Name);

            if (category)
            {
                throw new Exception($"Name{dto.Name} already exists");
            }

            _dbContext.Add(category);
            _dbContext.SaveChanges();

        }



        public void DeleteCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);


            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }

        }

        public void CreateQuestion(QuestionDto dto, int id)
        {
            var question = _mapper.Map<CreateQuestionDto>(dto);

            var quest = _mapper.Map<Question>(question);
            quest.CategoryId = id;

            _dbContext.Questions.Add(quest);
            _dbContext.SaveChanges();


            var questionId = quest.Id;

            var answers = _mapper.Map<Answer>(dto);

            answers.QuestionId = questionId;

            _dbContext.Answers.Add(answers);
            _dbContext.SaveChanges();


        }


       
    }
}
