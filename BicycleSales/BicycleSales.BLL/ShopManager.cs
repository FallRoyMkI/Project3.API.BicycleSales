using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL;

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

        public Shop CreateNewShop(Shop shop)
        {
            var shopDto = _mapper.MapShopToShopDto(shop);
            var callback = ((ShopRepository)_shopRepository).CreateNewShop(shopDto);
            var result = _mapper.MapShopDtoToShop(callback);

            return result;
        }

        public IEnumerable<Shop> GetAllShops()
        {
            var shopsDto = ((ShopRepository)_shopRepository).GetAllShops();
            var result = _mapper.MapListShopDtoToListShop(shopsDto);

            return result;
        }

        public Shop GetShopById(int id)
        {
            var shopDto = ((ShopRepository)_shopRepository).GetShopById(id);
            var result = _mapper.MapShopDtoToShop(shopDto);

            return result;
        }

        public Shop DeleteShop(int id)
        {
            var callback = ((ShopRepository)_shopRepository).DeleteShop(id);
            var result = _mapper.MapShopDtoToShop(callback);

            return result;
        }
    }
}
