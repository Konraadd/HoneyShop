using HoneyShop.Entities;
using Microsoft.EntityFrameworkCore;


namespace HoneyShop.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByCategoryId(int categoryId);
        Product GetById(int id);
    }

    public class ProductService : IProductService
    {
        private readonly HoneyShopDbContext _dbContext;

        public ProductService(HoneyShopDbContext honeyShopDbContext)
        {
            _dbContext = honeyShopDbContext;
        }
        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            var category = _dbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
                throw new Exception("Not found");

            return category.Products.ToList();
        }

        public Product GetById(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(c => c.Id == id);
            if (product == null)
                throw new Exception("Not found");

            return product;
        }
    }


}
