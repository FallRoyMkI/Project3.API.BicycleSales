using BicycleSales.Constants.CustomExceptions;
using BicycleSales.Constants.CustomExceptions.Product;
using BicycleSales.Constants.CustomExceptions.ProductTag;
using BicycleSales.Constants.CustomExceptions.Tag;
using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;
using System.Data;

namespace BicycleSales.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context = null)
        {
            _context = context ?? new Context();
        }

        public async Task<ProductDto> CreateProduct(ProductDto product)
        {
            if(_context.Products
                .ToList().Find(p => p.Name == product.Name) is not null) 
            {
                throw new ProductException($"Продукт с таким Name:{product.Name} существует");
            }
            else if (product.Cost <= 0)
            {
                throw new ProductException("Цена продукта должна быть больше 0");
            }
            else
            {
                product.IsDeleted = false;
                _context.Products.Add(product);
                _context.SaveChanges();
                return _context.Products.Single(p => p.Id == product.Id);
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var existingProducts = _context.Products
                .Where(p => p.IsDeleted == false).ToList();
            
            if(existingProducts.Count > 0)
            {
                return existingProducts;
            }
            else
            {
                throw new ProductException("Список продуктов пуст");
            }
        }

        public async Task<ProductDto> UpdateProduct(ProductDto product)
        {
            var existingModel = _context.Products
                 .ToList().Find(p => p.Id == product.Id);

            if (existingModel is not null)
            {
                existingModel.Name = product.Name;
                existingModel.Cost = product.Cost;
                _context.SaveChanges();
                
                return existingModel;
            }
            else
            {
                throw new ProductException($"Продукта с id:{product.Id} не существует");
            }
        }

        public async Task<ProductDto> DeleteProduct(int id)
        {
            var existingModel = _context.Products
                .ToList().Find(p => p.Id == id);
            
            if (existingModel is not null)
            {
                if(existingModel.IsDeleted == true)
                {
                    throw new ProductException($"Продукт c id:{id} уже и так удалён");
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
                throw new ProductException($"Продукта с id:{id} не существует");
            }
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var existingModel = _context.Products
                .ToList().Find(p => p.Id == id);

            if (existingModel is not null)
            {
                if (existingModel.IsDeleted == true)
                {
                    throw new ProductException($"Продукт с id:{id} удалён");
                }
                else
                {
                    return existingModel;                
                }
            }
            else
            {
                throw new ProductException($"Продукта с id:{id} не существует");
            }
        }

        public async Task<TagDto> CreateTag(TagDto tag)
        {
            var _existingTag = _context.Tags
                .ToList().Find(t => t.Name == tag.Name);

            if (_existingTag is not null)
            {
                throw new TagException($"Тэг с таким именем:{tag.Name} уже существует");
            }
            else
            {
                _context.Tags.Add(tag);
                _context.SaveChanges();
                return _context.Tags.Single(t => t.Id == tag.Id);
            }
        }
        public async Task<ProductTagDto> AddProductTag(int productId, int tagId)
        {
            var existingProduct = _context.Products
                .Where(p => p.IsDeleted == false).ToList().Find(p => p.Id == productId);
            
            var existingTag = _context.Tags
                .ToList().Find(t => t.Id == tagId);

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
                    throw new ProductTagException($"ProductTag с productId:{productId} и с tagId:{tagId} уже существует");;
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
                if (existingProduct is null) { throw new ProductException($"Продукта с productId:{productId} не существует"); }
                else if (existingTag is null) { throw new TagException($"Тэга с existingTag:{existingTag} не существует"); }
                else { throw new ProductTagException($"Продукта с productId:{productId} не существует и Тэга с existingTag:{existingTag} не существует"); }
            }
        }

        public bool IsProductExist(int id)
        {
            return _context.Products.ToList().Exists(x => x.Id == id && x.IsDeleted == false);
        }
    }
}
