using HoneyShop.Models;
using HoneyShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoneyShop.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var products = _productService.GetById(id);
            return Ok(products);
        }

        [HttpGet("category/{id}")]
        public ActionResult GetByCategoryId([FromRoute] int id)
        {
            var products = _productService.GetByCategoryId(id);
            return Ok(products);
        }

        [HttpPost]
        public ActionResult Create(CreateProductDto dto)
        {
            int newProductId = _productService.Create(dto);

            return Created($"api/product/{newProductId}", null);
        }
    }
}
