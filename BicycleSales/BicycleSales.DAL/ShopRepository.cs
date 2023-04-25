using BicycleSales.Constants.CustomExceptions.Shop;
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

        public async Task<ShopDto> CreateNewShop(ShopDto shop)
        {
            if (_context.Shops.ToList().Find(s => s.Location == shop.Location) is not null)
            {
                throw new ShopException($"Магазин с таким Location:{shop.Location} уже существует");
            }
            else
            {
                _context.Shops.Add(shop);
                _context.SaveChanges();

                return _context.Shops.Single(s => s.Id == shop.Id);
            }
        }
        public async Task<IEnumerable<ShopDto>> GetAllShops()
        {
            var existingShops = _context.Shops.Where(s => s.IsDeleted == false).ToList();

            if(existingShops.Count > 0)
            {
                return _context.Shops.Where(s => s.IsDeleted == false).ToList();
            }
            else
            {
                throw new ShopException("Список магазинов пуст");
            }
        }

        public async Task<ShopDto> GetShopById(int id)
        {
            var existingShop = _context.Shops.ToList().Find(s => s.Id == id);

            if (existingShop is not null)
            {
                if (existingShop.IsDeleted == true)
                {
                    throw new ShopException($"Магазин с id:{id} удалён");
                }
                else
                {
                    return existingShop;
                }
            }
            else
            {
                throw new ShopException($"Магазина с id:{id} не существует");
            }
        }

        public async Task<ShopDto> DeleteShop(int id)
        {
            var existingModel = _context.Shops.ToList().Find(s => s.Id == id);

            if (existingModel is not null)
            {
                if (existingModel.IsDeleted == true)
                {
                    throw new ShopException($"Магазин c id:{id} уже и так удалён");
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
                throw new ShopException($"Магазина с id:{id} не существует");
            }
        }
    }
}
