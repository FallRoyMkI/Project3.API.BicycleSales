using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Models;

namespace BicycleSales.DAL
{
    public class ProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context = null)
        {
            _context = context ?? new ProductContext();
        }

        public ProductDto CreateProduct(ProductDto product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return product;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _context.Product.ToList();
        }
    }
}
