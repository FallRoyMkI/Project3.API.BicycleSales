using BicycleSales.BLL.Models;
using BicycleSales.DAL;

namespace BicycleSales.BLL
{
    public class ProductManager
    {
        private readonly MapperBLL _mapper;
        public ProductManager(MapperBLL mapper = null)
        {
            _mapper = mapper ?? new MapperBLL();
        }
        public Product CreateProduct(Product prodcut)
        {
            var productDto = _mapper.MapProductToProductDto(prodcut);
            var callback = new ProductRepository().CreateProduct(productDto);
            var result = _mapper.MapProductDtoToProduct(callback);

            return result;
        }
    }
}
