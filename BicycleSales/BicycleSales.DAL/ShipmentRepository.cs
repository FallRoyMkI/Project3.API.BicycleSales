using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;

namespace BicycleSales.DAL;

public class ShipmentRepository : IShipmentRepository
{
    private readonly ShipmentContext _context;

    public ShipmentRepository(ShipmentContext context = null)
    {
        _context = context ?? new ShipmentContext();
    }

    public ShipmentDto CreateNewShipment(ShipmentDto shipment)
    {
        _context.Shipments.Add(shipment);
        _context.SaveChanges();

        return shipment;
    }

    public ShipmentDto UpdateShipment(ShipmentDto shipment)
    {
        var update = _context.Shipments.ToList().Find(x => x.Id == shipment.Id);
        if (update is null) throw new ArgumentException("Cannot find shipment with such Id");

        update.FactTime = shipment.FactTime;
        update.SignedBy = shipment.SignedBy;

        _context.SaveChanges();
        return update;
    }

    public ShipmentProductDto AddProductToShipment(ShipmentProductDto shipmentProduct)
    {
        _context.ShipmentProduct.Add(shipmentProduct);
        _context.SaveChanges();

        return shipmentProduct;
    }

    public ShipmentProductDto UpdateProductInShipment(ShipmentProductDto shipmentProduct)
    {
        var update = _context.ShipmentProduct.ToList().Find(x => x.Id == shipmentProduct.Id);
        if (update is null) throw new ArgumentException("Cannot find shipmentProduct with such Id");

        update.FactProductCount = shipmentProduct.FactProductCount;

        return update;
    }
}