using BicycleSales.BLL.Models;

namespace BicycleSales.BLL.Interfaces;

public interface IShipmentAcceptanceManager
{
    public Task<ShipmentAcceptance> CreateShipmentAcceptanceAsync(ShipmentAcceptance shipmentAcceptance);
    public Task<ShipmentAcceptance> GetShipmentAcceptanceById(int id);
}