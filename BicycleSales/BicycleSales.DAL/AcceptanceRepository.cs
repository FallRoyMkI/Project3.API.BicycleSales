using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleSales.DAL;

public class AcceptanceRepository : IAcceptanceRepository
{
    private readonly Context _context = new Context();

    public AcceptanceRepository(Context context = null)
    {
        _context = context ?? new Context();
    }

    public AcceptanceDto CreateNewAcceptance(AcceptanceDto acceptance)
    {
        _context.Acceptances.Add(acceptance);
        _context.SaveChanges();

        return _context.Acceptances
            .Single(p => p.Id == acceptance.Id);
    }

    public AcceptanceDto UpdateAcceptance(AcceptanceDto acceptance)
    {
        var update = _context.Acceptances.ToList().Find(x => x.Id == acceptance.Id)!;

        update.FactTime = acceptance.FactTime;
        update.SignedById = acceptance.SignedById;

        _context.SaveChanges();

        return _context.Acceptances
            .Single(p => p.Id == update.Id);
    }

    public AcceptanceProductDto AddProductToAcceptance(AcceptanceProductDto acceptanceProduct)
    {
        _context.AcceptanceProducts.Add(acceptanceProduct);
        _context.SaveChanges();

        return _context.AcceptanceProducts
            .Single(p => p.Id == acceptanceProduct.Id);
    }

    public AcceptanceProductDto UpdateProductInAcceptance(AcceptanceProductDto acceptanceProduct)
    {
        var update = _context.AcceptanceProducts.ToList().
            Find(x => x.ProductId == acceptanceProduct.ProductId
                      && x.AcceptanceId == acceptanceProduct.AcceptanceId)!;

        update.FactProductCount = acceptanceProduct.FactProductCount;
        _context.SaveChanges();

        return _context.AcceptanceProducts
            .Single(p => p.Id == update.Id);
    }

    public AcceptanceDto GetAcceptanceById(int id)
    {
        return _context.Acceptances
            .Include(p => p.FormedBy)
            .Include(p => p.Shop)
            .Include(p => p.SignedBy)
            .Single(x => x.Id == id)!;
    }

    public bool IsAcceptanceExist(int id)
    {
        return _context.Acceptances.ToList().Exists(x => x.Id == id);
    }

    public bool IsProductExistInAcceptance(int acceptanceId, int productId)
    {
        return _context.AcceptanceProducts.ToList().
            Exists(x => x.ProductId == productId && x.AcceptanceId == acceptanceId);
    }
    public bool IsFactCountAlreadyAdded(int acceptanceId, int productId)
    {
        return _context.AcceptanceProducts.ToList()
            .Exists(x => x.ProductId == productId &&
                         x.AcceptanceId == acceptanceId && x.FactProductCount != null);
    }

    public bool IsAcceptanceSigned(int id)
    {
        return _context.Acceptances.ToList().Exists(x => x.Id == id && x.SignedById is not null);
    }

    public IEnumerable<AcceptanceProductDto> GetAllProductFromAcceptanceById(int id)
    {
        return _context.AcceptanceProducts.ToList().FindAll(x => x.AcceptanceId == id);
    }
}