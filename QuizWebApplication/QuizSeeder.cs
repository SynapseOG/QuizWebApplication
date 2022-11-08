using QuizWebApplication.Data;
using QuizWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebApplication
{
    public interface IQuizSeeder
    {
        void Seed();
    }
    public class QuizSeeder : IQuizSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public QuizSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Seed();
        }
         

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Rankings.Any())
                {
                    var ranking = GetRanking();
                    _dbContext.Rankings.AddRange(ranking);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Name = "History",
                    Description = "Questions about history of the world",

                    Questions = new List<Question>()
                    {
                        new Question()
                        {
                            QuestionContent = "When WW2 has started? ",

                           Answer = new Answer()
                           {
                                AnswerContentA = "1914",
                                AnswerContentB = "1918",
                                AnswerContentC = "1939",
                                AnswerContentD = "1945",

                                CorrectAnswer = "1939"
                           }
                        },


                        new Question()
                        {
                            QuestionContent = "When WW1 has ended?",

                            Answer=new Answer()
                            {
                                 AnswerContentA = "1914",
                                AnswerContentB = "1918",
                                AnswerContentC = "1939",
                                AnswerContentD = "1945",

                                CorrectAnswer   ="1918"
                            }
                        }
                    }

                },

                new Category()
                {
                    Name = "Biology",
                    Description = "Questions about biology"
                },
                new Category()
                {
                    Name = "Computer Science",
                    Description = "Questions about computers"

                },
                new Category()
                {
                    Name = "Music",
                    Description = "Questions about music"
                },
                new Category()
                {
                    Name = "Football",
                    Description = "Questions about football"
                },
                new Category()
                {
                    Name = "Chemistry",
                    Description = "Questions about chemistry"
                }

            };
            return categories;
        }

        private IEnumerable<Ranking> GetRanking()
        {
            var userCount = _dbContext.Users.Count();

            var ranking = new List<Ranking>();

            var userList = new List<string>();

            foreach (var user in _dbContext.Users)
            {
                userList.Add(user.UserName);
            }

            for (int i = 0; i < userCount; i++)
            {
                ranking.Add(new Ranking()
                {
                    UserName = userList[i],
                    Points = 0,
                    PercentOfGoodAnswers = 0,

                });
            }
            return ranking;
           


        }
    }
}
