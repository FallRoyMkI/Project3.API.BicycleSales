using BicycleSales.API.Models.User.Response;
using BicycleSales.API.Models.User.Request;
using BicycleSales.BLL.Models;
using AutoMapper;
using BicycleSales.BLL.Interfaces;
using BicycleSales.API.Models.AuthorizationProduct.Request;
using BicycleSales.API.Models.AuthorizationProduct.Response;

namespace BicycleSales.API.MapperProfiles;

public class MapperApiUserProfile : Profile
{
    
    public MapperApiUserProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<UserAddRequest, User>();

        CreateMap<Authorization, AuthorizationResponse>();
        CreateMap<AuthorizationAddRequest, Authorization>();
        CreateMap<AuthorizationAddByAdminRequest, Authorization>();

        CreateMap<AuthorizationUpdateRequest, Authorization>();
        CreateMap<AuthorizationUpdateByAdminRequest, Authorization>();
    }
}