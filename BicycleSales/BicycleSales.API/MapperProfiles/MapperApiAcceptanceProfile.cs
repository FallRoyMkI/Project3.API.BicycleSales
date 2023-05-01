using AutoMapper;
using BicycleSales.API.Models.Acceptance.Request;
using BicycleSales.API.Models.Acceptance.Response;
using BicycleSales.API.Models.AcceptanceProduct.Request;
using BicycleSales.API.Models.AcceptanceProduct.Response;
using BicycleSales.BLL.Models;

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
        CreateMap<Acceptance, FullAcceptanceInfoResponse>();
    }
}