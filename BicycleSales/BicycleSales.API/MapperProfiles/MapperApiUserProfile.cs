using BicycleSales.API.Models.User.Response;
using BicycleSales.API.Models.User.Request;
using BicycleSales.BLL.Models;
using AutoMapper;
using BicycleSales.BLL.Interfaces;

namespace BicycleSales.API.MapperProfiles;

public class MapperApiUserProfile : Profile
{
    private IShopManager kek;
    public MapperApiUserProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<UserAddRequest, User>()
            .ForMember(x=> x.Shop, 
                y =>y.MapFrom(x=> kek.GetInfoAboutTheShopById(x.ShopId)));
    }
}