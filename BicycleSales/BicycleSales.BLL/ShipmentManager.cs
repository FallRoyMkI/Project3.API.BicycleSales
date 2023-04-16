using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.DAL;
using BicycleSales.DAL.Interfaces;

namespace BicycleSales.BLL;

public class ShipmentManager : IShipmentManager
{
    private readonly IMapperBLL _mapper;
    private readonly IShipmentRepository _shipmentRepository;

    public ShipmentManager(IMapperBLL mapper = null, IShipmentRepository shipmentRepository = null)
    {
        _mapper = mapper ?? new MapperBLL();
        _shipmentRepository = shipmentRepository ?? new ShipmentRepository();
    }

    public Shipment CreateNewShipment(Shipment shipment)
    {
        var dto = _mapper.MapShipmentToShipmentDto(shipment);
        var callback = _shipmentRepository.CreateNewShipment(dto);
        var result = _mapper.MapShipmentDtoToShipment(callback);

        return result;
    }

    public Shipment UpdateShipment(Shipment shipment)
    {
        var dto = _mapper.MapShipmentToShipmentDto(shipment);
        var callback = _shipmentRepository.UpdateShipment(dto);
        var result = _mapper.MapShipmentDtoToShipment(callback);

        return result;
    }

    public ShipmentProduct AddProductToShipment(ShipmentProduct shipmentProduct)
    {
        var dto = _mapper.MapShipmentProductToShipmentProductDto(shipmentProduct);
        var callback = _shipmentRepository.AddProductToShipment(dto);
        var result = _mapper.MapShipmentProductDtoToShipmentProduct(callback);

        return result;
    }

    public ShipmentProduct UpdateProductInShipment(ShipmentProduct shipmentProduct)
    {
        var dto = _mapper.MapShipmentProductToShipmentProductDto(shipmentProduct);
        var callback = _shipmentRepository.UpdateProductInShipment(dto);
        var result = _mapper.MapShipmentProductDtoToShipmentProduct(callback);

        return result;
    }
}