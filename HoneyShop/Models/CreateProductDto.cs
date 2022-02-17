using System.ComponentModel.DataAnnotations;

namespace HoneyShop.Models
{
    public class CreateProductDto
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Size { get; set; }
    }
}
