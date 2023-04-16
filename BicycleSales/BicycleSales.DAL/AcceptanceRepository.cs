using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;

namespace BicycleSales.DAL;

public class AcceptanceRepository : IAcceptanceRepository
{
    private readonly AcceptanceContext _context;

    public AcceptanceRepository(AcceptanceContext context = null)
    {
        _context = context ?? new AcceptanceContext();
    }

    public AcceptanceDto CreateNewAcceptance(AcceptanceDto acceptance)
    {
        _context.Acceptances.Add(acceptance);
        _context.SaveChanges();

        return acceptance;
    }

    public AcceptanceDto UpdateAcceptance(AcceptanceDto acceptance)
    {
        var update = _context.Acceptances.ToList().Find(x => x.Id == acceptance.Id);
        if (update is null) throw new ArgumentException("Cannot find acceptance with such Id");

        update.FactTime = acceptance.FactTime;
        update.SignedBy = acceptance.SignedBy;

        _context.SaveChanges();
        return update;
    }

    public AcceptanceProductDto AddProductToAcceptance(AcceptanceProductDto acceptanceProduct)
    {
        _context.AcceptanceProduct.Add(acceptanceProduct);
        _context.SaveChanges();

        return acceptanceProduct;
    }

    public AcceptanceProductDto UpdateProductInAcceptance(AcceptanceProductDto acceptanceProduct)
    {
        var update = _context.AcceptanceProduct.ToList().Find(x => x.Id == acceptanceProduct.Id);
        if (update is null) throw new ArgumentException("Cannot find acceptanceProduct with such Id");

        update.FactProductCount = acceptanceProduct.FactProductCount;

        return update;
    }
}