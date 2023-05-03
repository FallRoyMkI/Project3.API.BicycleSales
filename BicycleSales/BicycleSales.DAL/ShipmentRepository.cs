using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleSales.DAL;

public class ShipmentRepository : IShipmentRepository
{
    private readonly Context _context;

    public ShipmentRepository(Context context = null)
    {
        _context = context ?? new Context();
    }

    public ShipmentDto CreateNewShipment(ShipmentDto shipment)
    {
        _context.Shipments.Add(shipment);
        _context.SaveChanges();

        return _context.Shipments
            .Single(p => p.Id == shipment.Id);
    }

    public ShipmentDto UpdateShipment(ShipmentDto shipment)
    {
        var update = _context.Shipments.ToList().Find(x => x.Id == shipment.Id)!;

        update.FactTime = shipment.FactTime;
        update.SignedById = shipment.SignedById;

        _context.SaveChanges();

        return _context.Shipments
            .Single(p => p.Id == update.Id);
    }

    public ShipmentProductDto AddProductToShipment(ShipmentProductDto shipmentProduct)
    {
        _context.ShipmentProducts.Add(shipmentProduct);
        _context.SaveChanges();

        return _context.ShipmentProducts
            .Single(p => p.Id == shipmentProduct.Id);
    }

    public ShipmentProductDto UpdateProductInShipment(ShipmentProductDto shipmentProduct)
    {
        var update = _context.ShipmentProducts.ToList().
            Find(x => x.ProductId == shipmentProduct.ProductId
                      && x.ShipmentId == shipmentProduct.ShipmentId)!;

        update.FactProductCount = shipmentProduct.FactProductCount;
        _context.SaveChanges();

        return _context.ShipmentProducts
            .Single(p => p.Id == update.Id);
    }

    public ShipmentDto GetShipmentById(int id)
    {
        return _context.Shipments
            .Include(p => p.FormedBy)
            .Include(p => p.Shop)
            .Include(p => p.SignedBy)
            .Single(x => x.Id == id)!;
    }

    public bool IsShipmentExist(int id)
    {
        return _context.Shipments.ToList().Exists(x => x.Id == id);
    }

    public bool IsProductExistInShipment(int shipmentId, int productId)
    {
        return _context.ShipmentProducts.ToList().
            Exists(x => x.ProductId == productId && x.ShipmentId == shipmentId);
    }

    public bool IsFactCountAlreadyAdded(int shipmentId, int productId)
    {
        return _context.ShipmentProducts.ToList()
            .Exists(x => x.ProductId == productId &&
                         x.ShipmentId == shipmentId && x.FactProductCount != null);
    }

    public bool IsShipmentSigned(int id)
    {
        return _context.Shipments.ToList().Exists(x => x.Id == id && x.SignedById is not null);
    }

    public IEnumerable<ShipmentProductDto> GetAllProductFromShipmentById(int id)
    {
        return _context.ShipmentProducts.
            ToList().FindAll(x => x.ShipmentId == id);
    }

}