using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizWebApplication.Data;
using QuizWebApplication.Models;

namespace QuizWebApplication.Controllers
{
    [AllowAnonymous]
    public class RankingController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public RankingController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult GetRanking()
        {
            var ranking = _dbContext.Rankings.ToList();

            List<Ranking> SortedList = ranking.OrderByDescending(o => o.Points).ToList();


            return View(SortedList);
        }
        


    }
}
