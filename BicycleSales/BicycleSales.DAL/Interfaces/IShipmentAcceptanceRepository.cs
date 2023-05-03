using BicycleSales.DAL.Models;

namespace BicycleSales.DAL.Interfaces;

public interface IShipmentAcceptanceRepository
{
    public Task<ShipmentAcceptanceDto> CreateShipmentAcceptanceAsync(ShipmentAcceptanceDto shipmentAcceptanceDto);

    public Task<ShipmentAcceptanceDto> GetShipmentAcceptanceAsync(int? shipmentId = null,
        int? acceptanceId = null);

    public Task<ShipmentAcceptanceDto> UpdateShipmentAcceptanceAsync(ShipmentAcceptanceDto shipmentAcceptanceDto);
    public Task<ShipmentAcceptanceDto> GetShipmentAcceptanceById(int id);
    public bool IsShipmentAcceptanceExist(int id);
    public bool IsShipmentAcceptanceCreatedEarlier(int shipmentId, int acceptanceId);
}