using BicycleSales.Constants.CustomExceptions;
using BicycleSales.Constants.CustomExceptions.Product;
using BicycleSales.Constants.CustomExceptions.ProductTag;
using BicycleSales.Constants.CustomExceptions.Tag;
using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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

        public async Task<ProductDto> CreateProductAsync(ProductDto product)
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

        public async Task<ProductDto> UpdateProductAsync(ProductDto product)
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

        public async Task<ProductDto> DeleteProductAsync(int id)
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

        public async Task<ProductDto> GetProductByIdAsync(int id)
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

        public async Task<TagDto> CreateTagAsync(TagDto tag)
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
        public async Task<ProductTagDto> AddProductTagAsync(int productId, int tagId)
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

                if (_context.ProductTags.Any(p => p.Id == productTagDto.TagId && p.Id == productTagDto.ProductId))
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

        public async Task<IEnumerable<TagDto>> GetAllTagsAsync(int? id)
        {
            if (id is not null)
            {
                if(!IsProductExist((int)id))
                {
                    throw new ProductException($"Продукта с id:{id} не существует или он удалён");
                }

                List<ProductTagDto> existingProductTags = _context.ProductTags
                    .Include(t => t.Tag)
                    .Where(p => p.ProductId == id)
                    .ToList(); 

                if (existingProductTags.Count() == 0)
                {
                    throw new ProductTagException($"Список тэгов с productId:{id} пуст");
                }

                List<TagDto> existingTags = new List<TagDto>();

                foreach (var i in existingProductTags)
                {
                    existingTags.Add(i.Tag);
                }

                return existingTags;
            }
            else
            {
                var existingTags = _context.Tags.ToList();

                if(existingTags.Count() == 0)
                {
                    throw new TagException("Список тэгов пуст");
                }

                return existingTags;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsByTagIdAsync(int id)
        {
            if(!IsTagtExist(id))
            {
                throw new TagException($"Тэга с id:{id} не существует");
            }

            List<ProductTagDto> existingProductTags = _context.ProductTags
                .Include(t => t.Product)
                .Where(p => p.TagId == id)
                .ToList();

            if (existingProductTags.Count() == 0)
            {
                throw new ProductTagException($"Список продуктов с tagId:{id} пуст");
            }

            List<ProductDto> existingProducts = new List<ProductDto>();

            foreach (var i in existingProductTags)
            {
                existingProducts.Add(i.Product);
            }

            return existingProducts;
        }
        public bool IsTagtExist(int id)
        {
            return _context.Tags.ToList().Exists(x => x.Id == id);
        }
        public bool IsProductExist(int id)
        {
            return _context.Products.ToList().Exists(x => x.Id == id && x.IsDeleted == false);
        }
    }
}
