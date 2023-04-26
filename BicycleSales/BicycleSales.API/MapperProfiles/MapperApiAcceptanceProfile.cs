using BicycleSales.API.Models.AuthorizationProduct.Response;
using BicycleSales.API.Models.AuthorizationProduct.Request;
using BicycleSales.BLL.Models;
using AutoMapper;
using BicycleSales.API.Models.Acceptance.Request;
using BicycleSales.API.Models.Acceptance.Response;
using BicycleSales.API.Models.AcceptanceProduct.Request;
using BicycleSales.API.Models.AcceptanceProduct.Response;

namespace BicycleSales.API.MapperProfiles;

public class MapperApiAcceptanceProfile : Profile
{

    public MapperApiAcceptanceProfile()
    {
        CreateMap<Acceptance, AcceptanceResponse>();
        CreateMap<AcceptanceAddRequest, Acceptance>();
        CreateMap<AcceptanceUpdateRequest, Acceptance>();
        CreateMap<AcceptanceProductAddRequest, AcceptanceProduct>();
        CreateMap<AcceptanceProductUpdateRequest, AcceptanceProduct>();
        CreateMap<AcceptanceProduct, AcceptanceProductResponse>();
    }
}