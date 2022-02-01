using HoneyShop.Entities;
using HoneyShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoneyShop.Controllers
{
    [Route("api/[controller]")]
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
    }
}
