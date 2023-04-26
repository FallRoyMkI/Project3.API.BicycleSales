using BicycleSales.DAL.Models;

namespace BicycleSales.DAL.Interfaces;

public interface IAcceptanceRepository
{
    public AcceptanceDto CreateNewAcceptance(AcceptanceDto acceptance);

    public AcceptanceDto UpdateAcceptance(AcceptanceDto acceptance);

    public AcceptanceProductDto AddProductToAcceptance(AcceptanceProductDto acceptanceProduct);

    public AcceptanceProductDto UpdateProductInAcceptance(AcceptanceProductDto acceptanceProduct);
    
    public bool IsAcceptanceExist(int id);
    public bool IsProductExistInAcceptance(int acceptanceId, int productId);
    public bool IsFactCountAlreadyAdded(int acceptanceId, int productId);
    public AcceptanceDto GetAcceptanceById(int id);
    public bool IsAcceptanceSigned(int id);
    public IEnumerable<AcceptanceProductDto> GetAllProductFromAcceptanceById(int id);
}