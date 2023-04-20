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
    }
}
