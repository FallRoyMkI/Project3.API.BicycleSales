using BicycleSales.BLL.Models;
using BicycleSales.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleSales.BLL.Interfaces;
public interface IProductManager
{
    public Task<Product> CreateProduct(Product prodcut);
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<Product> UpdateProduct(Product prodcut);
    public Task<Product> DeleteProduct(int id);
    public Task<Product> GetProductById(int id);
    public Task<Tag> CreateTag(Tag tag);
    public Task<ProductTag> AddProductTag(int productId, int tagId);
    
}

