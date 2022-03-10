using AutoMapper;
using Dukkantek.Data.Models.Products;
using Dukkantek.Domain.Models;

namespace Dukkantek.Data.AutoMappings
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryDomain>()
               .ReverseMap();

            CreateMap<ProductCategory, ProductCategoryDomain>()
               .ReverseMap();
        }
    }
}
