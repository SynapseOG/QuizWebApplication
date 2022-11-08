using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizWebApplication.Models.Dto;
using QuizWebApplication.Services;

namespace QuizWebApplication.Controllers
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IAdminService _adminService;
        public AdminController(ICategoryService categoryService, IMapper mapper, IAdminService adminService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _adminService = adminService;
        }
       
       public IActionResult Management()
       {
            return View();
       }

       public IActionResult GetCategories()
       {
            var categories = _categoryService.GetAll();
            return View(categories);
       }

       public IActionResult CreateCategory()
       {
            return View();
       }

       [HttpPost]
       public IActionResult CreateCategory(CategoryDto dto)
       {
            _adminService.CreateCategory(dto);
            return View();
       }
       
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null)
                return NotFound();

            var category = _categoryService.GetById(id);

            return View(category);
        }

       [HttpPost]
       public IActionResult DeleteCategoryPost(int? id)
       {
            if(id == null || id==0)
            {
                return NotFound();
            }
            return RedirectToAction("GetCategories");


       }

        public IActionResult CreateQuestion(CategoryDto dto)
        {
            var categoryId = dto.Id;
            TempData["id"] = categoryId;

            return View();
        }

        [HttpPost]
        public IActionResult CreateQuestionPost(QuestionDto dto)
        {
            var id = Convert.ToInt32(TempData["id"]);

            _adminService.CreateQuestion(dto, id);


            return RedirectToAction("CreateQuestion");
        }

    }
}
