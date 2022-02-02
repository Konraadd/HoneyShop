using AutoMapper;
using HoneyShop.Entities;
using HoneyShop.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyShop.Services
{
    public interface IInventoryService
    {
        IEnumerable<InventoryDto> GetAll();
        InventoryDto GetByProductId(int productId);
    }

    public class InventoryService : IInventoryService
    {
        private readonly HoneyShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public InventoryService(HoneyShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<InventoryDto> GetAll()
        {
            var inventories =  _dbContext.Inventory
                .Include(i => i.Product)
                .ThenInclude(p => p.Category)
                .ToList();

            var inventoriesDto = _mapper.Map<List<InventoryDto>>(inventories);

            return inventoriesDto;
        }

        public InventoryDto GetByProductId(int productId)
        {
            var inventory = _dbContext.Inventory
                .Include(i => i.Product)
                .ThenInclude(p => p.Category)
                .FirstOrDefault(x => x.ProductId == productId);
            if (inventory == null)
                throw new Exception("Not found");

            var inventoryDto = _mapper.Map<InventoryDto>(inventory);

            return inventoryDto;
        }
    }
}
