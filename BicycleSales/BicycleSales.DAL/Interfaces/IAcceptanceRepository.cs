using BicycleSales.DAL.Models;

namespace BicycleSales.DAL.Interfaces;

public interface IAcceptanceRepository
{
    public AcceptanceDto CreateNewAcceptance(AcceptanceDto acceptance);

    public AcceptanceDto UpdateAcceptance(AcceptanceDto acceptance);

    public AcceptanceProductDto AddProductToAcceptance(AcceptanceProductDto acceptanceProduct);

    public AcceptanceProductDto UpdateProductInAcceptance(AcceptanceProductDto acceptanceProduct);
}