using BicycleSales.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleSales.DAL.Interfaces
{
    public interface IProductRepository
    {
        public Task<ProductDto> CreateProduct(ProductDto product);
        public Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        public Task<ProductDto> UpdateProduct(ProductDto product);
        public Task<ProductDto> DeleteProduct(int id);
        public Task<ProductDto> GetProductById(int id);
        public Task<TagDto> CreateTag(TagDto tag);
        public Task<ProductTagDto> AddProductTag(int productId, int tagId);
    }
}
