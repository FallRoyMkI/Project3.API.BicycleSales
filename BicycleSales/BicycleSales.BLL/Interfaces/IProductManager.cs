using BicycleSales.BLL.Models;
using BicycleSales.DAL;

namespace BicycleSales.BLL.Interfaces;

public interface IProductManager
{
    public Product CreateProduct(Product prodcut);

    public IEnumerable<Product> GetAllProducts();

    public Product UpdateProduct(Product prodcut);

    public Product DeleteProduct(int id);

    public Product GetProductById(int id);

    public Tag CreateTag(Tag tag);

    public ProductTag AddProductTag(int productId, int tagId);
}