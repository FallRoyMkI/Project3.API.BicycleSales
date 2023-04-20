﻿using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;

namespace BicycleSales.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context = null)
        {
            _context = context ?? new Context();
        }

        public ProductDto CreateProduct(ProductDto product)
        {
            if(_context.Products.ToList().Find(p => p.Name == product.Name) is not null) 
            {
                throw new Exception($"Продукт с таким Name:{product.Name} существует");
            }
            else if (product.Cost <= 0)
            {
                throw new Exception("Цена продукта должна быть больше 0");
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return _context.Products.Single(p => p.Id == product.Id);
            }
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var existingProducts = _context.Products.Where(p => p.IsDeleted == false).ToList();
            
            if(existingProducts.Count > 0)
            {
                return existingProducts;
            }
            else
            {
                throw new Exception("Список продуктов пуст");
            }
        }

        public ProductDto UpdateProduct(ProductDto product)
        {
            var existingModel = _context.Products
                 .Single(p => p.Id == product.Id);

            existingModel.Name = product.Name;
            existingModel.Cost = product.Cost;
            _context.SaveChanges();

            return existingModel;
        }

        public ProductDto DeleteProduct(int id)
        {
            var existingModel = _context.Products.ToList().Find(p => p.Id == id);
            
            if (existingModel is not null)
            {
                if(existingModel.IsDeleted == true)
                {
                    throw new Exception($"Продукт c id:{id} уже и так удалён");
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
                throw new Exception($"Продукта с id:{id} не существует");
            }
        }

        public ProductDto GetProductById(int id)
        {
            var existingModel = _context.Products.ToList().Find(p => p.Id == id);

            if (existingModel is not null)
            {
                if (existingModel.IsDeleted == true)
                {
                    throw new Exception($"Продукт с id:{id} удалён");
                }
                else
                {
                    return existingModel;                
                }
            }
            else
            {
                throw new Exception($"Продукта с id:{id} не существует");
            }
        }

        public TagDto CreateTag(TagDto tag)
        {
            var _existingTag = _context.Tags.ToList().Find(t => t.Name == tag.Name);

            if (_existingTag is not null)
            {
                throw new Exception("Тэг с таким именем существует");
            }
            else
            {
                _context.Tags.Add(tag);
                _context.SaveChanges();
                return _context.Tags.Single(t => t.Id == tag.Id);
            }
        }
        public ProductTagDto AddProductTag(int productId, int tagId)
        {
            var existingProduct = _context.Products.Where(p => p.IsDeleted == false).ToList().Find(p => p.Id == productId);
            var existingTag = _context.Tags.ToList().Find(t => t.Id == tagId);

            if (existingProduct is not null && existingTag is not null) 
            {
                var productTagDto = new ProductTagDto()
                {
                    Product = existingProduct,
                    Tag = existingTag,
                    ProductId = productId,
                    TagId = tagId
                };

                if (_context.ProductTags.Any(p => p == productTagDto))
                {
                    throw new Exception($"ProductTag с productId:{productId} и с tagId:{tagId} уже существует");;
                }
                else
                {
                    _context.ProductTags.Add(productTagDto);
                    _context.SaveChanges();
                    return productTagDto;
                }
            }
            else 
            {
                if (existingProduct is null) { throw new Exception($"Продукта с productId:{productId} не существует"); }
                else if (existingTag is null) { throw new Exception($"Тэга с existingTag:{existingTag} не существует"); }
                else { throw new Exception($"Продукта с productId:{productId} не существует и Тэга с existingTag:{existingTag} не существует"); }
            }
        }
    }
}
