using System.ComponentModel.DataAnnotations;

namespace HoneyShop.Models
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
