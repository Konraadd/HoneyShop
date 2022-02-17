using HoneyShop.Entities;
using HoneyShop.Models;
using HoneyShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoneyShop.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute]int id)
        {
            var category = _categoryService.Get(id);
            return Ok(category);
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryDto dto)
        {
            int newCategoryId = _categoryService.Create(dto);

            return Created($"api/category/{newCategoryId}", null);
        }
    }
}
