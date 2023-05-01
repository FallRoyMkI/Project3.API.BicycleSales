using BicycleSales.Constants.CustomExceptions.Product;
using BicycleSales.Constants.CustomExceptions.Shop;
using BicycleSales.Constants.CustomExceptions.ShopProduct;
using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BicycleSales.DAL;

public class ShopRepository : IShopRepository
{
    private readonly Context _context;

    public ShopRepository(Context context = null)
    {
        _context = context ?? new Context();
    }

    public async Task<ShopDto> CreateNewShop(ShopDto shop)
    {
        if (IsShopLocationExist(shop) == true)
        {
            throw new ShopException($"Магазин с таким Location:{shop.Location} уже существует");
        }

        _context.Shops.Add(shop);
        _context.SaveChanges();

        return _context.Shops.Single(s => s.Id == shop.Id);
    }


    public async Task<IEnumerable<ShopDto>> GetAllShops()
    {
        return _context.Shops.ToList();
    }

    public async Task<ShopDto> GetShopById(int id)
    {
        var existingShop = _context.Shops.ToList().Find(s => s.Id == id);

        if (existingShop is not null)
        {
            return existingShop;
        }

        throw new ShopException($"Магазина с id:{id} не существует");

    }

    public async Task<IEnumerable<ShopProductDto>> GetAllProductsByShopId(int id)
    {
        if (!IsShopExist(id))
        {
            throw new ShopException($"Магазина с таким id:{id} не существует");
        }

        var existingShopProducts = _context.ShopProducts
            .Include(p => p.Product)
            .Where(p => p.ShopId == id)
            .Where(p => p.Product.IsDeleted == false)
            .ToList();

        if(existingShopProducts.Count == 0)
        {
            throw new ShopProductException($"Список продуктов с shopId:{id} пуст");
        }

        return existingShopProducts;
    }

    public async Task<ShopProductDto> AddProductInShopAsync(ShopProductDto shopProductDto)
    {
        if (IsShopProductExist(shopProductDto))
        {
            var existingModel = _context.ShopProducts
                .ToList()
                .Find(s => s.ProductId == shopProductDto.ProductId && s.ShopId == shopProductDto.ShopId);

            existingModel.ProductCount += shopProductDto.ProductCount;
            _context.SaveChanges();

            var existingShopProducts = _context.ShopProducts.
                Include(s => s.Shop).
                Include(p => p.Product).
                Single(x => x.Id == existingModel.Id);
            
            return existingShopProducts;
        }
        else
        {
            if (!IsShopExist(shopProductDto.Shop.Id) && !IsProductExist(shopProductDto.Product.Id))
            {
                throw new ShopProductException($"Магазина с id:{shopProductDto.Shop.Id} и продукта с id:{shopProductDto.Product.Id} не существует");
            }
            else if (!IsShopExist(shopProductDto.Shop.Id))
            {
                throw new ShopException($"Магазина с id:{shopProductDto.Shop.Id}");
            }
            else if (!IsProductExist(shopProductDto.Product.Id))
            {
                throw new ProductException($"Продукта с id:{shopProductDto.Product.Id} не существует");
            }
            else
            {
                _context.ShopProducts.Add(shopProductDto);
                _context.SaveChanges();

                return _context.ShopProducts.Single(s => s.Id == shopProductDto.Id);
            }
        }
    }
    public async Task<ShopProductDto> DeleteProductCountInShopAsync(ShopProductDto shopProductDto)
    {
        if (IsShopProductExist(shopProductDto))
        {
            if (!IsShopExist(shopProductDto.ShopId))
            {
                throw new ShopProductException($"Магазина с id:{shopProductDto.ShopId} не существует"); 
            }
            else if (!IsProductExist(shopProductDto.ProductId))
            {
                throw new ProductException($"Продукта с id:{shopProductDto.ProductId} не существует");
            }

            var existingModel = _context.ShopProducts
                .ToList()
                .Find(s => s.ProductId == shopProductDto.ProductId && s.ShopId == shopProductDto.ShopId);
            
            var difference = existingModel.ProductCount - shopProductDto.ProductCount;
            if (difference >= 0) 
            {
                existingModel.ProductCount = difference;
                _context.SaveChanges();
            }
            else
            {
                throw new ProductException($"На удаление не хватает {difference*(-1)} продукта!");;
            } 

            var existingShopProducts = _context.ShopProducts.
                Include(s => s.Shop).
                Include(p => p.Product).
                Single(x => x.Id == existingModel.Id);

            return existingShopProducts;
        }
        else if (!IsShopExist(shopProductDto.ShopId) && IsProductExist(shopProductDto.ProductId))
        {
            throw new ShopProductException($"Магазина с id:{shopProductDto.ShopId} не существует");
        }
        else if (!IsProductExist(shopProductDto.ProductId) && IsShopExist(shopProductDto.ShopId))
        {
            throw new ProductException($"Продукта с id:{shopProductDto.ProductId} не существует");
        }
        else
        {
            throw new ShopException($"Нет магазина с id:{shopProductDto.ShopId} и продукта с id:{shopProductDto.ProductId}");
        }
    }
    public bool IsShopExist(int id)
    {
        return _context.Shops.ToList().Exists(x => x.Id == id);
    }
    public bool IsProductExist(int id)
    {
        return _context.Products.ToList().Exists(x => x.Id == id);
    }
    public bool IsShopProductExist(ShopProductDto shopProductDto)
    {
        return _context.ShopProducts.ToList().Exists(x => x.ShopId == shopProductDto.ShopId && x.ProductId == shopProductDto.ProductId);
    }

    private bool IsShopLocationExist(ShopDto shop)
    {
        return _context.Shops.ToList().Exists(s => s.Location == shop.Location);
    }
}