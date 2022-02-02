using AutoMapper;
using HoneyShop.Entities;
using HoneyShop.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyShop.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAll();
    }

    public class CategoryService : ICategoryService
    {
        private readonly HoneyShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(HoneyShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories =  _dbContext.Categories.ToList();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesDto;

        }
    }
}
