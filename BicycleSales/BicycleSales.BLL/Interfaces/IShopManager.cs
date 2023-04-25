using BicycleSales.BLL.Models;

namespace BicycleSales.BLL.Interfaces;
public interface IShopManager
{
    public Task<Shop> CreateNewShop(Shop shop);
    public Task<IEnumerable<Shop>> GetAllShops();
    public Task<Shop> GetShopById(int id);
    public Task<Shop> DeleteShop(int id);
}

