using BicycleSales.BLL.Models;
using BicycleSales.Constants;

namespace BicycleSales.BLL.Interfaces;

public interface IShipmentManager
{
    public Task<Shipment> CreateNewShipment(Shipment shipment);
    public Task<ShipmentProduct> AddProductToShipment(ShipmentProduct shipmentProduct);
    public Task<ShipmentProduct> UpdateProductInShipment(ShipmentProduct shipmentProduct);

    public Task<Shipment> UpdateShipment(Shipment shipment);

    public Task<Shipment> GetShipmentById(int id);

    public Task<IEnumerable<ShipmentProduct>> GetAllProductFromShipmentById(int id);
}