using AutoMapper;
using BicycleSales.API.Models.Product.Request;
using BicycleSales.API.Models.Product.Response;
using BicycleSales.API.Models.ProductTag.Request;
using BicycleSales.API.Models.ShopProduct.Request;
using BicycleSales.API.Models.ShopProduct.Response;
using BicycleSales.API.Models.Tag.Request;
using BicycleSales.API.Models.Tag.Response;
using BicycleSales.BLL.Models;

namespace BicycleSales.API.MapperProfiles
{
    public class MapperApiProductProfile : Profile
    {
        public MapperApiProductProfile() 
        {
            CreateMap<ProductAddRequest, Product>();
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductUpdateRequest, Product>();
            
            CreateMap<ShopProductAddRequest, ShopProduct>();
            CreateMap<ShopProduct, ShopProductResponse>(); 
            
            CreateMap<TagAddRequest, Tag>();
            CreateMap<Tag, TagResponse>();

            CreateMap<ProductTag, ProductTagResponse>();
        }
    }
}
