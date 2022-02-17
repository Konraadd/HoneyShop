using AutoMapper;
using HoneyShop.Entities;
using HoneyShop.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyShop.Services
{
    public interface ICategoryService
    {
        int Create(CreateCategoryDto dto);
        void Delete(int id);
        CategoryDto Get(int id);
        IEnumerable<CategoryDto> GetAll();
        void Update(ModifyCategoryDto dto, int id);
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
        
        public CategoryDto Get(int id)
        {
            var category = _dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories =  _dbContext.Categories.ToList();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesDto;

        }

        public int Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return category.Id;
        }

        public void Update(ModifyCategoryDto dto, int id)
        {
            var category = _dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (category == null)
                throw new ArgumentException("Not found");

            category.Name = dto.Name;
            category.Description = dto.Description;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (category == null)
                throw new Exception("not found");

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }
    }
}
