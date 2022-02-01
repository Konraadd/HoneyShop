using HoneyShop.Entities;

namespace HoneyShop.Services
{
    public interface IInventoryService
    {
        IEnumerable<Inventory> GetAll();
        Inventory GetByProductId(int productId);
    }

    public class InventoryService : IInventoryService
    {
        private readonly HoneyShopDbContext _dbContext;

        public InventoryService(HoneyShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Inventory> GetAll()
        {
            return _dbContext.Inventory.ToList();
        }

        public Inventory GetByProductId(int productId)
        {
            var inventory = _dbContext.Inventory.FirstOrDefault(x => x.ProductId == productId);
            if (inventory == null)
                throw new Exception("Not found");

            return inventory;
        }
    }
}
