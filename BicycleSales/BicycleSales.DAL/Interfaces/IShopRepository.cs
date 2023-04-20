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
        public ShopDto CreateNewShop(ShopDto shop);
        public IEnumerable<ShopDto> GetAllShops();
        public ShopDto GetShopById(int id);
        public ShopDto DeleteShop(int id);
    }
}
