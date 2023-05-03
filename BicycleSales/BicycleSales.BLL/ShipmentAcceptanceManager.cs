using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.Constants;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;

namespace BicycleSales.BLL;

public class ShipmentAcceptanceManager :IShipmentAcceptanceManager
{
    private readonly IMapperBLL _mapper;
    private readonly IShipmentAcceptanceRepository _shipAccRepository;
    private readonly IShipmentRepository _shipmentRepository;
    private readonly IAcceptanceRepository _acceptanceRepository;

    public ShipmentAcceptanceManager(IMapperBLL mapper, IShipmentAcceptanceRepository shipAccRepository,
        IShipmentRepository shipmentRepository, IAcceptanceRepository acceptanceRepository)
    {
        _mapper = mapper;
        _shipAccRepository = shipAccRepository;
        _shipmentRepository = shipmentRepository;
        _acceptanceRepository = acceptanceRepository;
    }

    public async Task<ShipmentAcceptance> CreateShipmentAcceptanceAsync(ShipmentAcceptance shipmentAcceptance)
    {
        if (_shipAccRepository.IsShipmentAcceptanceCreatedEarlier(shipmentAcceptance.ShipmentId,
                shipmentAcceptance.AcceptanceId))
            throw new RepetativeActionException("Adding", "ShipmentAcceptance");

        var kek = _acceptanceRepository.GetAllProductFromAcceptanceById(shipmentAcceptance.AcceptanceId).ToList();
        var pep = _shipmentRepository.GetAllProductFromShipmentById(shipmentAcceptance.ShipmentId).ToList();

        if (kek.Count() != pep.Count()) throw new Exception();

        for (var i = 0; i < kek.Count(); i++)
        {
            if (kek[i].ProductCount != pep[i].ProductCount) throw new Exception();
        }
        var shipmentAcceptanceDto = _mapper.MapShipmentAcceptanceToShipmentAcceptanceDto(shipmentAcceptance);
        shipmentAcceptanceDto.Status = ShipmentAcceptanceStatus.ShipmentAcceptanceCreated;
        var callback = await _shipAccRepository.CreateShipmentAcceptanceAsync(shipmentAcceptanceDto);
        var result = _mapper.MapShipmentAcceptanceDtoToShipmentAcceptance(callback);

        return result;
    }

    public async Task<ShipmentAcceptance> GetShipmentAcceptanceById(int id)
    {
        if (!_shipAccRepository.IsShipmentAcceptanceExist(id))
            throw new ObjectNotExistException("ShipmentAcceptance", id);

        var callback = await _shipAccRepository.GetShipmentAcceptanceById(id);
        var result = _mapper.MapShipmentAcceptanceDtoToShipmentAcceptance(callback);

        return result;
    }
}
