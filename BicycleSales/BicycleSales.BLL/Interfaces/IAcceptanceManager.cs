using BicycleSales.BLL.Models;

namespace BicycleSales.BLL.Interfaces;

public interface IAcceptanceManager
{
    public Task<Acceptance> CreateNewAcceptance(Acceptance acceptance);
    public Task<Acceptance> UpdateAcceptance(Acceptance acceptance);

    public Task<AcceptanceProduct> AddProductToAcceptance(AcceptanceProduct acceptanceProduct);

    public Task<AcceptanceProduct> UpdateProductInAcceptance(AcceptanceProduct acceptanceProduct);
    
    public Task<Acceptance> GetAcceptanceById(int id);
    public Task<IEnumerable<AcceptanceProduct>> GetAllProductFromAcceptanceById(int id);

    
}