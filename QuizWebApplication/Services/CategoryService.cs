using AutoMapper;
using QuizWebApplication.Data;
using QuizWebApplication.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebApplication.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAll();
        public CategoryDto GetById(int? id);

    }
    public class CategoryService : ICategoryService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;


        public CategoryService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        //get data from db and map on dto then return as dto
        public  IEnumerable<CategoryDto> GetAll()
        {
            var categories = _dbContext.Categories
                .ToList();

            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesDtos;

        }
        public CategoryDto GetById(int? id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id");
            }

            var category = _dbContext.Categories.Find(id);

            var dto = _mapper.Map<CategoryDto>(category);

            return dto;
        }
        
       
    }
}
