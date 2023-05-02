using AutoMapper;
using BicycleSales.API.Models.Order.Request;
using BicycleSales.API.Models.Order.Response;
using BicycleSales.API.Models.OrderProduct.Request;
using BicycleSales.API.Models.OrderProduct.Response;
using BicycleSales.BLL.Models;

namespace BicycleSales.API.MapperProfiles;

public class MapperApiOrderProfile : Profile
{
    public MapperApiOrderProfile()
    {
        CreateMap<Order, OrderResponse>();
        CreateMap<OrderAddRequest, Order>();
        CreateMap<OrderUpdateRequest, Order>();
        CreateMap<OrderProductAddRequest, OrderProduct>();
        CreateMap<OrderProductUpdateRequest, OrderProduct>();
        CreateMap<OrderProduct, OrderProductResponse>();
    }
}