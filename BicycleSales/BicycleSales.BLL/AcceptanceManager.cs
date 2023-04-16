using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.DAL;
using BicycleSales.DAL.Interfaces;

namespace BicycleSales.BLL;

public class AcceptanceManager : IAcceptanceManager
{
    private readonly IMapperBLL _mapper;
    private readonly IAcceptanceRepository _acceptanceRepository;

    public AcceptanceManager(IMapperBLL mapper = null, IAcceptanceRepository acceptanceRepository = null)
    {
        _mapper = mapper ?? new MapperBLL();
        _acceptanceRepository = acceptanceRepository ?? new AcceptanceRepository();
    }

    public Acceptance CreateNewAcceptance(Acceptance acceptance)
    {
        var dto = _mapper.MapAcceptanceToAcceptanceDto(acceptance);
        var callback = _acceptanceRepository.CreateNewAcceptance(dto);
        var result = _mapper.MapAcceptanceDtoToAcceptance(callback);

        return result;
    }

    public Acceptance UpdateAcceptance(Acceptance acceptance)
    {
        var dto = _mapper.MapAcceptanceToAcceptanceDto(acceptance);
        var callback = _acceptanceRepository.UpdateAcceptance(dto);
        var result = _mapper.MapAcceptanceDtoToAcceptance(callback);

        return result;
    }

    public AcceptanceProduct AddProductToAcceptance(AcceptanceProduct acceptanceProduct)
    {
        var dto = _mapper.MapAcceptanceProductToAcceptanceProductDto(acceptanceProduct);
        var callback = _acceptanceRepository.AddProductToAcceptance(dto);
        var result = _mapper.MapAcceptanceProductDtoToAcceptanceProduct(callback);

        return result;
    }

    public AcceptanceProduct UpdateProductInAcceptance(AcceptanceProduct acceptanceProduct)
    {
        var dto = _mapper.MapAcceptanceProductToAcceptanceProductDto(acceptanceProduct);
        var callback = _acceptanceRepository.UpdateProductInAcceptance(dto);
        var result = _mapper.MapAcceptanceProductDtoToAcceptanceProduct(callback);

        return result;
    }
}