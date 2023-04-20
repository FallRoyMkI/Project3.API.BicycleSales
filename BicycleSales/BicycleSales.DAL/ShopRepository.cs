using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleSales.DAL
{
    public class ShopRepository : IShopRepository
    {
        private readonly Context _context;

        public ShopRepository(Context context = null)
        {
            _context = context ?? new Context();
        }

        public ShopDto CreateNewShop(ShopDto shop)
        {
            if (_context.Shops.ToList().Find(s => s.Location == shop.Location) is not null)
            {
                throw new Exception($"Магазин с таким Location:{shop.Location} уже существует");
            }
            else
            {
                _context.Shops.Add(shop);
                _context.SaveChanges();

                return _context.Shops.Single(s => s.Id == shop.Id);
            }
        }
        public IEnumerable<ShopDto> GetAllShops()
        {
            var existingShops = _context.Shops.Where(s => s.IsDeleted == false).ToList();

            if(existingShops.Count > 0)
            {
                return _context.Shops.Where(s => s.IsDeleted == false).ToList();
            }
            else
            {
                throw new Exception("Список магазинов пуст");
            }
        }

        public ShopDto GetShopById(int id)
        {
            var existingShop = _context.Shops.ToList().Find(s => s.Id == id);

            if (existingShop is not null)
            {
                if (existingShop.IsDeleted == true)
                {
                    throw new Exception($"Магазин с id:{id} удалён");
                }
                else
                {
                    return existingShop;
                }
            }
            else
            {
                throw new Exception($"Магазина с id:{id} не существует");
            }
        }

        public ShopDto DeleteShop(int id)
        {
            var existingModel = _context.Shops.ToList().Find(s => s.Id == id);

            if (existingModel is not null)
            {
                if (existingModel.IsDeleted == true)
                {
                    throw new Exception($"Магазин c id:{id} уже и так удалён");
                }
                else
                {
                    existingModel.IsDeleted = true;
                    _context.SaveChanges();

                    return existingModel;
                }
            }
            else
            {
                throw new Exception($"Магазина с id:{id} не существует");
            }
        }
    }
}
