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
        public Task<ProductDto> CreateProductAsync(ProductDto product);
        public Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        public Task<ProductDto> UpdateProductAsync(ProductDto product);
        public Task<ProductDto> DeleteProductAsync(int id);
        public Task<ProductDto> GetProductByIdAsync(int id);
        public Task<TagDto> CreateTagAsync(TagDto tag);
        public Task<ProductTagDto> AddProductTagAsync(int productId, int tagId);
        public bool IsProductExist(int id);
        public Task<IEnumerable<TagDto>> GetAllTagsAsync(int? id);
        public Task<IEnumerable<ProductDto>> GetAllProductsByTagIdAsync(int id);
    }
}
