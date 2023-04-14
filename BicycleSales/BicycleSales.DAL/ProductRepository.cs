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
            return _context.Product.Single(p => p.Id == product.Id); 
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _context.Product.Where(t => t.IsDeleted == false).ToList();
        }

        public ProductDto UpdateProduct(ProductDto product)
        {
            var existingModel = _context.Product
                 .Single(t => t.Id == product.Id);

            existingModel.Name = product.Name;
            existingModel.Cost = product.Cost;

            _context.SaveChanges();

            return existingModel;
        }   
    }
}
