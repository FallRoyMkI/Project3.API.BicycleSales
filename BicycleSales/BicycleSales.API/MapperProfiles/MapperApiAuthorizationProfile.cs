using BicycleSales.API.Models.AuthorizationProduct.Response;
using BicycleSales.API.Models.AuthorizationProduct.Request;
using BicycleSales.BLL.Models;
using AutoMapper;

namespace BicycleSales.API.MapperProfiles;

public class MapperApiAuthorizationProfile : Profile
{

    public MapperApiAuthorizationProfile()
    {
        CreateMap<Authorization, AuthorizationResponse>();
        CreateMap<AuthorizationAddRequest, Authorization>();
        CreateMap<AuthorizationAddByAdminRequest, Authorization>();

        CreateMap<AuthorizationUpdateRequest, Authorization>();
        CreateMap<AuthorizationUpdateByAdminRequest, Authorization>();
    }
}