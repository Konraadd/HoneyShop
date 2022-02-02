using AutoMapper;
using HoneyShop.Entities;
using HoneyShop.Models;

namespace HoneyShop
{
    public class HoneyShopModelsMappingProfile : Profile
    {
        public HoneyShopModelsMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(c => c.Category.Name));
            CreateMap<Inventory, InventoryDto>();
        }
    }
}
