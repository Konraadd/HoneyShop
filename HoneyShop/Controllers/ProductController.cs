using HoneyShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoneyShop.Controllers
{
    [ApiController]
    [Route("/api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;


    }
}
