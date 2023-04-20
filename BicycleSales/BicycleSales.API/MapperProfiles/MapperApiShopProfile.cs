using AutoMapper;
using BicycleSales.API.Models.Shop.Request;
using BicycleSales.API.Models.Shop.Response;
using BicycleSales.BLL.Models;

namespace BicycleSales.API.MapperProfiles
{
    public class MapperApiShopProfile : Profile
    {
        public MapperApiShopProfile() 
        { 
            CreateMap<Shop, ShopResponse>();
            CreateMap<ShopAddRequest, Shop>();
        }
    }
}
