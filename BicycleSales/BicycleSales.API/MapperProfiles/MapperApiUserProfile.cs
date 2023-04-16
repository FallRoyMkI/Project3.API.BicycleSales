using BicycleSales.API.Models.User.Response;
using BicycleSales.API.Models.User.Request;
using BicycleSales.BLL.Models;
using AutoMapper;
using BicycleSales.BLL.Interfaces;

namespace BicycleSales.API.MapperProfiles;

public class MapperApiUserProfile : Profile
{
    
    public MapperApiUserProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<UserAddRequest, User>();
    }
}