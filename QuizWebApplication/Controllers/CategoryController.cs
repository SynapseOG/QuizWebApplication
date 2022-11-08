using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizWebApplication.Models.Dto;
using QuizWebApplication.Services;

namespace QuizWebApplication.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //return view with data 
        
        public IActionResult CategoryMainView()
        {
            var category = _categoryService.GetAll();

            return View(category);
        }


        public IActionResult DescriptionCategoryView(CategoryDto categoryDto)
        {

            return View(categoryDto);
        }
    }
}
