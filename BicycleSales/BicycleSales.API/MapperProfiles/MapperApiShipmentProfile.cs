using BicycleSales.BLL.Models;
using AutoMapper;
using BicycleSales.API.Models.Shipment.Request;
using BicycleSales.API.Models.Shipment.Response;

namespace BicycleSales.API.MapperProfiles;

public class MapperApiShipmentProfile : Profile
{

    public MapperApiShipmentProfile()
    {
        CreateMap<Shipment, ShipmentResponse>();
        CreateMap<ShipmentAddRequest, Shipment>();
    }
}