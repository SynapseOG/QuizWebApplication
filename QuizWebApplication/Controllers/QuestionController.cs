using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizWebApplication.Data;
using QuizWebApplication.Models;
using QuizWebApplication.Models.Dto;
using QuizWebApplication.Services;

namespace QuizWebApplication.Controllers
{
    [AllowAnonymous]
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IQuestionService _service;
        private readonly IRankingService _rankService;
        private readonly UserManager<IdentityUser> _userManager;
        public QuestionController(ApplicationDbContext applicationDbContext, IMapper mapper,
            IQuestionService questionService, IRankingService rankService, UserManager<IdentityUser> userManager)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
            _service = questionService;
            _rankService = rankService;
            _userManager = userManager;
        }
       



        public IActionResult QuestionView(CategoryDto dto)
        {

           var questionDto =  _service.GetQuestions(dto);

            return View(questionDto);
        }

        [HttpPost]
        public IActionResult QuestionView(IFormCollection formCollection) // 0 i parzyste indeksy to pytania
        {
            var points = _service.SetAnswers(formCollection);

            return RedirectToAction("PointsView", new { points = points });
        }

        [AllowAnonymous]
        public async Task<IActionResult> PointsView(int points)
        {
            var model = new Pointer();
            model.Points = points;

            const int maxPoints = 2;

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if(user != null)
            {
                _rankService.AddPoints(user.UserName, points,maxPoints);
            }

            return View(model);
        }
        
    }
}
