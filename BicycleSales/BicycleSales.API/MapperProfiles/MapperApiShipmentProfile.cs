using AutoMapper;
using BicycleSales.API.Models.Shipment.Request;
using BicycleSales.API.Models.Shipment.Response;
using BicycleSales.API.Models.ShipmentProduct.Request;
using BicycleSales.API.Models.ShipmentProduct.Response;
using BicycleSales.BLL.Models;

namespace BicycleSales.API.MapperProfiles;

public class MapperApiShipmentProfile : Profile
{

    public MapperApiShipmentProfile()
    {
        CreateMap<Shipment, ShipmentResponse>();
        CreateMap<ShipmentAddRequest, Shipment>();
        CreateMap<ShipmentUpdateRequest, Shipment>();
        CreateMap<ShipmentProductAddRequest, ShipmentProduct>();
        CreateMap<ShipmentProductUpdateRequest, ShipmentProduct>();
        CreateMap<ShipmentProduct, ShipmentProductResponse>();
        CreateMap<Shipment, FullShipmentInfoResponse>();
        CreateMap<ShipmentProduct, ShipmentProductLowInfoResponse>();
    }
}