using HoneyShop.Entities;
using HoneyShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoneyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventorySerivce)
        {
            _inventoryService = inventorySerivce;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Inventory>> GetAll()
        {
            var inventories = _inventoryService.GetAll();
            return Ok(inventories);
        }

        [HttpGet("{productId}")]
        public ActionResult<Inventory> GetByProductId(int productId)
        {
            var inventory = _inventoryService.GetByProductId(productId);
            return Ok(inventory);
        }
    }
}
