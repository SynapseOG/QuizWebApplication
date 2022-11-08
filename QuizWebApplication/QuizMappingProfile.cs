using AutoMapper;
using QuizWebApplication.Models.Dto;
using QuizWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Identity;

namespace QuizWebApplication
{
    public class QuizMappingProfile : Profile
    {
        public QuizMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Question, QuestionDto>()
                .ForMember(r => r.AnswerA, c => c.MapFrom(s => s.Answer.AnswerContentA))
                .ForMember(r => r.AnswerB, c => c.MapFrom(s => s.Answer.AnswerContentB))
                .ForMember(r => r.AnswerC, c => c.MapFrom(s => s.Answer.AnswerContentC))
                .ForMember(r => r.AnswerD, c => c.MapFrom(s => s.Answer.AnswerContentD))
                .ForMember(r => r.CorrectAnswer, c => c.MapFrom(s => s.Answer.CorrectAnswer))
                .ForMember(r => r.QuestionId, c => c.MapFrom(s => s.Answer.QuestionId));


            CreateMap<QuestionDto, CreateQuestionDto>();
            CreateMap<CreateQuestionDto, Question>();

            CreateMap<QuestionDto, Answer>()
                .ForMember(r => r.AnswerContentA, c => c.MapFrom(s => s.AnswerA))
                .ForMember(r => r.AnswerContentB, c => c.MapFrom(s => s.AnswerB))
                .ForMember(r => r.AnswerContentC, c => c.MapFrom(s => s.AnswerC))
                .ForMember(r => r.AnswerContentD, c => c.MapFrom(s => s.AnswerD))
                .ForMember(r => r.CorrectAnswer, c => c.MapFrom(s => s.CorrectAnswer));

            CreateMap<Ranking,RankingDto>();

            CreateMap<IdentityUser, Ranking>()
                 .ForMember(r => r.UserName, c => c.MapFrom(s => s.UserName));



        }
    }
}
