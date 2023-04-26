using AutoMapper;
using BicycleSales.API.Models.Order.Request;
using BicycleSales.API.Models.Order.Response;
using BicycleSales.BLL.Models;

namespace BicycleSales.API.MapperProfiles
{
    public class MapperApiOrderProfile : Profile
    {
        public MapperApiOrderProfile() 
        { 
            CreateMap<Order, OrderResponse>();
            CreateMap<OrderAddRequest, Order>();
        }
    }
}
