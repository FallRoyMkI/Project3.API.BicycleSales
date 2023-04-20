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
    }
}
