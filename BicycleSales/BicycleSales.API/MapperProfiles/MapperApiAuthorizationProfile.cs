using BicycleSales.API.Models.AuthorizationProduct.Response;
using BicycleSales.API.Models.AuthorizationProduct.Request;
using BicycleSales.BLL.Models;
using AutoMapper;
using BicycleSales.API.Models.Acceptance.Request;
using BicycleSales.API.Models.Acceptance.Response;

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

        CreateMap<AcceptanceAddRequest, Acceptance>().ForMember(t => t.FormedBy, x => x.MapFrom(y => y.UserIdWhichFormed));
        CreateMap<Acceptance, AcceptanceResponse>();
    }
}