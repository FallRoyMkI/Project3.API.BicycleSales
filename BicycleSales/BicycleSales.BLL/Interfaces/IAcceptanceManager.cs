using BicycleSales.BLL.Models;

namespace BicycleSales.BLL.Interfaces;

public interface IAcceptanceManager
{
    public Acceptance CreateNewAcceptance(Acceptance acceptance);

    public Acceptance UpdateAcceptance(Acceptance acceptance);

    public AcceptanceProduct AddProductToAcceptance(AcceptanceProduct acceptanceProduct);

    public AcceptanceProduct UpdateProductInAcceptance(AcceptanceProduct acceptanceProduct);
}