using BicycleSales.BLL.Models;

namespace BicycleSales.BLL.Interfaces;
public interface IShopManager
{
    public Shop CreateNewShop(Shop shop);
    public IEnumerable<Shop> GetAllShops();
    public Shop GetShopById(int id);
    public Shop DeleteShop(int id);
}

