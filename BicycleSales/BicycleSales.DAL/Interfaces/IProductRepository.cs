using BicycleSales.DAL.Models;

namespace BicycleSales.DAL.Interfaces;

public interface IProductRepository
{
    public ProductDto CreateProduct(ProductDto product);

    public IEnumerable<ProductDto> GetAllProducts();

    public ProductDto UpdateProduct(ProductDto product);

    public ProductDto DeleteProduct(int id);

    public ProductDto GetProductById(int id);

    public TagDto CreateTag(TagDto tag);
    public ProductTagDto AddProductTag(int productId, int tagId);
    public bool IsProductExist(int id);
}