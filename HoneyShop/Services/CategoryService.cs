using HoneyShop.Entities;

namespace HoneyShop.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
    }

    public class CategoryService : ICategoryService
    {
        private readonly HoneyShopDbContext _dbContext;

        public CategoryService(HoneyShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
