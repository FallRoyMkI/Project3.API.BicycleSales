using AutoMapper;
using BicycleSales.BLL.Models;
using BicycleSales.DAL;
using BicycleSales.DAL.Models;

namespace BicycleSales.BLL
{
    public class ProductManager
    {
        private readonly MapperBLL _mapper;
        private readonly ProductRepository _productRepository = new ProductRepository();

        public ProductManager(MapperBLL mapper = null)
        {
            _mapper = mapper ?? new MapperBLL();
        }
        public Product CreateProduct(Product prodcut)
        {
            var productDto = _mapper.MapProductToProductDto(prodcut);
            var callback = _productRepository.CreateProduct(productDto);
            var result = _mapper.MapProductDtoToProduct(callback);

            return result;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var productsDto = _productRepository.GetAllProducts();
            var result = _mapper.MapListProductDtoToListProduct(productsDto);
            
            return result;
        }
    }
}
