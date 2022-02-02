using HoneyShop.Entities;

namespace HoneyShop.Models
{
    public class CategoryDto
    {
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public IEnumerable<Product> Products { get; set; }
        }
    }
}
