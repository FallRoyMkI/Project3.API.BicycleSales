using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleSales.DAL.Interfaces;

public interface IShipmentRepository
{
    public ShipmentDto CreateNewShipment(ShipmentDto shipment);

    public ShipmentDto UpdateShipment(ShipmentDto shipment);

    public ShipmentProductDto AddProductToShipment(ShipmentProductDto shipmentProduct);

    public ShipmentProductDto UpdateProductInShipment(ShipmentProductDto shipmentProduct);
}