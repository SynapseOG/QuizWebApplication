using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QuizWebApplication.Data;
using QuizWebApplication.Models;

namespace QuizWebApplication.Services
{
    public interface IRankingService
    {
        void AddToRanking(string userName);
        void AddPoints(string userName, int points, int maxPoints);
    }
    public class RankingService : IRankingService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        public RankingService(ApplicationDbContext dbContext, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public void AddToRanking(string userName)
        {
            var ranking = new Ranking()
            {
                UserName = userName,
                Points = 0,
                PercentOfGoodAnswers = 0,
            };

            _dbContext.Rankings.Add(ranking);
            _dbContext.SaveChanges();
        }
        public  void AddPoints(string userName, int points, int maxPoints)
        {
            var ranking =  _dbContext.Rankings.FirstOrDefault(x=>x.UserName==userName);

            ranking.GamesPlayed += 1;
              ranking.Points += points;

            double games = ranking.GamesPlayed;
            double point = ranking.Points;
            double maxPoint = maxPoints;
             
            double percentResult =  point / (games * maxPoint);

            ranking.PercentOfGoodAnswers = percentResult *100;


            _dbContext.UpdateRange(ranking);
            _dbContext.SaveChanges();

        }
       

    }
}
