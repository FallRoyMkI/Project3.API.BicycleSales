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

        public Product UpdateProduct(Product prodcut)
        {
            var productDto = _mapper.MapProductToProductDto(prodcut);
            var callback = _productRepository.UpdateProduct(productDto);
            var result = _mapper.MapProductDtoToProduct(callback);

            return result;
        }

        public Product DeleteProduct(int id)
        {
            var callback = _productRepository.DeleteProduct(id);
            var result = _mapper.MapProductDtoToProduct(callback);

            return result;
        }

        public Product GetProductById(int id)
        {
            var productsDto = _productRepository.GetProductById(id);
            var result = _mapper.MapProductDtoToProduct(productsDto);

            return result;
        }

        public Tag CreateTag(Tag tag)
        {
            var tagDto = _mapper.MapTagToTagDto(tag);
            var callback = _productRepository.CreateTag(tagDto);
            var result = _mapper.MapTagDtoToTag(callback);

            return result;
        }
        public ProductTag AddProductTag(int productId, int tagId)
        {
            var callback = _productRepository.AddProductTag(productId, tagId);
            var result = _mapper.MapProductTagDtoToProductTag(callback);

            return result;
        }
    }
}
