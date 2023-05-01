using BicycleSales.BLL.Models;

namespace BicycleSales.BLL.Interfaces;
public interface IShopManager
{
    public Task<Shop> CreateNewShop(Shop shop);
    public Task<IEnumerable<Shop>> GetAllShops();
    public Task<Shop> GetShopById(int id);
    public Task<IEnumerable<ShopProduct>> GetAllProductsByShopId(int id);
    public Task<ShopProduct> AddProductInShopAsync(ShopProduct shopProduct);
    public Task<ShopProduct> DeleteProductCountInShopAsync(ShopProduct shopProduct);
}

