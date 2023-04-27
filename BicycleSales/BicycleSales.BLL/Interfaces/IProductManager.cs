using BicycleSales.BLL.Models;
using BicycleSales.DAL;
using BicycleSales.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleSales.BLL.Interfaces;
public interface IProductManager
{
    public Task<Product> CreateProductAsync(Product prodcut);
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<Product> UpdateProductAsync(Product prodcut);
    public Task<Product> DeleteProductAsync(int id);
    public Task<Product> GetProductByIdAsync(int id);
    public Task<Tag> CreateTagAsync(Tag tag);
    public Task<ProductTag> AddProductTagAsync(int productId, int tagId);
    public Task<IEnumerable<Tag>> GetAllTagsAsync(int? id);
    public Task<IEnumerable<Product>> GetAllProductsByTagIdAsync(int id);
}

