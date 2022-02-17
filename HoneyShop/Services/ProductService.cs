using AutoMapper;
using HoneyShop.Entities;
using HoneyShop.Models;
using Microsoft.EntityFrameworkCore;


namespace HoneyShop.Services
{
    public interface IProductService
    {
        int Create(CreateProductDto dto);
        IEnumerable<ProductDto> GetAll();
        IEnumerable<ProductDto> GetByCategoryId(int categoryId);
        ProductDto GetById(int id);
    }

    public class ProductService : IProductService
    {
        private readonly HoneyShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(HoneyShopDbContext honeyShopDbContext, IMapper mapper)
        {
            _dbContext = honeyShopDbContext;
            _mapper = mapper;
        }
        public IEnumerable<ProductDto> GetAll()
        {
            var products = _dbContext.Products
                .Include(p => p.Category)
                .ToList();

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }

        public IEnumerable<ProductDto> GetByCategoryId(int categoryId)
        {
            var category = _dbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
                throw new Exception("Not found");

            var products = category.Products.ToList();

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }

        public ProductDto GetById(int id)
        {
            var product = _dbContext.Products
                .Include(p => p.Category)
                .FirstOrDefault(c => c.Id == id);
            if (product == null)
                throw new Exception("Not found");

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public int Create(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return product.Id;
        }
    }
}
