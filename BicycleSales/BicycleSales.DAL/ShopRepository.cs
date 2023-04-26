using BicycleSales.Constants.CustomExceptions.Shop;
using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;

namespace BicycleSales.DAL;

public class ShopRepository : IShopRepository
{
    private readonly Context _context;

    public ShopRepository(Context context = null)
    {
        _context = context ?? new Context();
    }

    public async Task<ShopDto> CreateNewShop(ShopDto shop)
    {
        if (_context.Shops.ToList().Find(s => s.Location == shop.Location) is not null)
        {
            throw new ShopException($"Магазин с таким Location:{shop.Location} уже существует");
        }

        _context.Shops.Add(shop);
        _context.SaveChanges();

        return _context.Shops.Single(s => s.Id == shop.Id);
    }


    public async Task<IEnumerable<ShopDto>> GetAllShops()
    {
        return _context.Shops.ToList();
    }

    public async Task<ShopDto> GetShopById(int id)
    {
        var existingShop = _context.Shops.ToList().Find(s => s.Id == id);

        if (existingShop is not null)
        {
            return existingShop;
        }

        throw new ShopException($"Магазина с id:{id} не существует");

    }


    public bool IsShopExist(int id)
    {
        return _context.Shops.ToList().Exists(x => x.Id == id);
    }
}