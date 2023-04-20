using AutoMapper;
using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.DAL;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;

namespace BicycleSales.BLL
{
    public class ProductManager : IProductManager
    {
        private readonly IMapperBLL _mapper;
        private readonly IProductRepository _productRepository;

        public ProductManager(IMapperBLL mapper = null, IProductRepository productRepository = null)
        {
            _mapper = mapper ?? new MapperBLL();
            _productRepository = productRepository ?? new ProductRepository();
        }
        public Product CreateProduct(Product prodcut)
        {
            var productDto = _mapper.MapProductToProductDto(prodcut);
            var callback = ((ProductRepository)_productRepository).CreateProduct(productDto);
            var result = _mapper.MapProductDtoToProduct(callback);

            return result;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var productsDto = ((ProductRepository)_productRepository).GetAllProducts();
            var result = _mapper.MapListProductDtoToListProduct(productsDto);
            
            return result;
        }

        public Product UpdateProduct(Product prodcut)
        {
            var productDto = _mapper.MapProductToProductDto(prodcut);
            var callback = ((ProductRepository)_productRepository).UpdateProduct(productDto);
            var result = _mapper.MapProductDtoToProduct(callback);

            return result;
        }

        public Product DeleteProduct(int id)
        {
            var callback = ((ProductRepository)_productRepository).DeleteProduct(id);
            var result = _mapper.MapProductDtoToProduct(callback);

            return result;
        }

        public Product GetProductById(int id)
        {
            var productsDto = ((ProductRepository)_productRepository).GetProductById(id);
            var result = _mapper.MapProductDtoToProduct(productsDto);

            return result;
        }

        public Tag CreateTag(Tag tag)
        {
            var tagDto = _mapper.MapTagToTagDto(tag);
            var callback = ((ProductRepository)_productRepository).CreateTag(tagDto);
            var result = _mapper.MapTagDtoToTag(callback);

            return result;
        }
        public ProductTag AddProductTag(int productId, int tagId)
        {
            var callback = ((ProductRepository)_productRepository).AddProductTag(productId, tagId);
            var result = _mapper.MapProductTagDtoToProductTag(callback);

            return result;
        }
    }
}
