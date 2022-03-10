using AutoMapper;
using Dukkantek.Data.Models.Products;
using Dukkantek.Domain.Models; 

namespace Dukkantek.Data.AutoMappings
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductDomain>()
               .ReverseMap();
        }
    }
}
