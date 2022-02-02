using HoneyShop.Entities;

namespace HoneyShop.Models
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public ProductDto Product{ get; set; }
        public int AvailableQuantity { get; set; }
    }
}
