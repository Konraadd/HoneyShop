using HoneyShop.Entities;

namespace HoneyShop.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Size { get; set; }
    }
}
