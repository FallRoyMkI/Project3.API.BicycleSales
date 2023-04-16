using BicycleSales.BLL.Models;

namespace BicycleSales.BLL.Interfaces;

public interface IShipmentManager
{
    public Shipment CreateNewShipment(Shipment shipment);

    public Shipment UpdateShipment(Shipment shipment);

    public ShipmentProduct AddProductToShipment(ShipmentProduct shipmentProduct);

    public ShipmentProduct UpdateProductInShipment(ShipmentProduct shipmentProduct);
}