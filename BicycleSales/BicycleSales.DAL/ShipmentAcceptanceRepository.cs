using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleSales.DAL;

public class ShipmentAcceptanceRepository : IShipmentAcceptanceRepository
{
    private readonly Context _context = new Context();

    public ShipmentAcceptanceRepository(Context context = null)
    {
        _context = context ?? new Context();
    }

    public async Task<ShipmentAcceptanceDto> CreateShipmentAcceptanceAsync(ShipmentAcceptanceDto shipmentAcceptanceDto)
    {
        _context.ShipmentAcceptances.Add(shipmentAcceptanceDto);
        _context.SaveChanges();

        return _context.ShipmentAcceptances
            .Single(x=> x.ShipmentId == shipmentAcceptanceDto.ShipmentId
            && x.AcceptanceId == shipmentAcceptanceDto.AcceptanceId);
    }

    public async Task<ShipmentAcceptanceDto> GetShipmentAcceptanceAsync(int? shipmentId = null,
        int? acceptanceId = null)
    {
        if (shipmentId == null)
        {
            return _context.ShipmentAcceptances.Single(x => x.AcceptanceId == acceptanceId);
        }

        return _context.ShipmentAcceptances.Single(x => x.ShipmentId == shipmentId);

    }

    public async Task<ShipmentAcceptanceDto> UpdateShipmentAcceptanceAsync(ShipmentAcceptanceDto shipmentAcceptanceDto)
    {
        var update = _context.ShipmentAcceptances.ToList().Find(x => x.Id == shipmentAcceptanceDto.Id)!;

        update.Status = shipmentAcceptanceDto.Status;

        _context.SaveChanges();

        return _context.ShipmentAcceptances
            .Include(p => p.Acceptance)
            .Include(p => p.Shipment)
            .Single(p => p.Id == update.Id);
    }

    public async Task<ShipmentAcceptanceDto> GetShipmentAcceptanceById(int id)
    {
        return _context.ShipmentAcceptances
            .Include(x=> x.Acceptance)
            .Include(x=>x.Acceptance.FormedBy)
            .Include(x=>x.Acceptance.Shop)
            .Include(x=>x.Acceptance.SignedBy)
            .Include(x=>x.Shipment)
            .Include(x=>x.Shipment.FormedBy)
            .Include(x=>x.Shipment.Shop)
            .Include(x=>x.Shipment.SignedBy)
            .Single(x => x.Id == id);
    }

    public bool IsShipmentAcceptanceExist(int id)
    {
        return _context.ShipmentAcceptances.ToList().Exists(x => x.Id == id);
    }

    public bool IsShipmentAcceptanceCreatedEarlier(int shipmentId, int acceptanceId)
    {
        return _context.ShipmentAcceptances.ToList().Exists(x => x.ShipmentId == shipmentId
                                                                 && x.AcceptanceId == acceptanceId);
    }
}