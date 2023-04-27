using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.DAL;
using BicycleSales.DAL.Interfaces;

namespace BicycleSales.BLL
{
    public class ShopManager : IShopManager
    {
        private readonly IMapperBLL _mapper;
        private readonly IShopRepository _shopRepository;

        public ShopManager(IMapperBLL mapper = null, IShopRepository shopRepository = null)
        {
            _mapper = mapper ?? new MapperBLL();
            _shopRepository = shopRepository ?? new ShopRepository();
        }

        public async Task<Shop> CreateNewShop(Shop shop)
        {
            var shopDto = _mapper.MapShopToShopDto(shop);
            var callback = await ((ShopRepository)_shopRepository).CreateNewShop(shopDto);
            var result = _mapper.MapShopDtoToShop(callback);

            return result;
        }

        public async Task<IEnumerable<Shop>> GetAllShops()
        {
            var shopsDto = await ((ShopRepository)_shopRepository).GetAllShops();
            var result = _mapper.MapListShopDtoToListShop(shopsDto);

            return result;
        }

        public async Task<Shop> GetShopById(int id)
        {
            var shopDto = await ((ShopRepository)_shopRepository).GetShopById(id);
            var result = _mapper.MapShopDtoToShop(shopDto);

            return result;
        }
        public async Task<IEnumerable<ShopProduct>> GetAllProductsByShopId(int id)
        {
            var shopsDto = await ((ShopRepository)_shopRepository).GetAllProductsByShopId(id);
            var result = _mapper.MapListShopProductDtoToListShopProduct(shopsDto);

            return result;
        }
        public async Task<ShopProduct> AddProductInShopAsync(ShopProduct shopProduct)
        {
            var shopProductDto = _mapper.MapShopProductToShopProductDto(shopProduct);
            var callback = await ((ShopRepository)_shopRepository).AddProductInShopAsync(shopProductDto);
            var result = _mapper.MapShopProductDtoToShopProduct(callback);

            return result;
        }
    }
}
