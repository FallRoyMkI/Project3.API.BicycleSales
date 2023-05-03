using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleSales.DAL.Interfaces;

public interface IShipmentRepository
{
    public ShipmentDto CreateNewShipment(ShipmentDto shipment);

    public ShipmentDto UpdateShipment(ShipmentDto shipment);

    public ShipmentProductDto AddProductToShipment(ShipmentProductDto shipmentProduct);

    public ShipmentProductDto UpdateProductInShipment(ShipmentProductDto shipmentProduct);

    public ShipmentDto GetShipmentById(int id);

    public bool IsShipmentExist(int id);

    public bool IsProductExistInShipment(int shipmentId, int productId);

    public bool IsFactCountAlreadyAdded(int shipmentId, int productId);

    public bool IsShipmentSigned(int id);

    public IEnumerable<ShipmentProductDto> GetAllProductFromShipmentById(int id);

    public Task<ShipmentAcceptanceDto> CreateShipmentAcceptanceAsync(ShipmentAcceptanceDto shipmentAcceptanceDto);
}