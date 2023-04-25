using BicycleSales.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleSales.DAL.Interfaces
{
    public interface IShopRepository
    {
        public Task<ShopDto> CreateNewShop(ShopDto shop);
        public Task<IEnumerable<ShopDto>> GetAllShops();
        public Task<ShopDto> GetShopById(int id);
        public Task<ShopDto> DeleteShop(int id);
    }
}
