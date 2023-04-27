using AutoMapper;
using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.DAL;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;

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
        public async Task<Product> CreateProductAsync(Product prodcut)
        {
            var productDto = _mapper.MapProductToProductDto(prodcut);
            var callback =await ((ProductRepository)_productRepository).CreateProductAsync(productDto);
            var result = _mapper.MapProductDtoToProduct(callback);

            return result;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var productsDto = await ((ProductRepository)_productRepository).GetAllProductsAsync();
            var result = _mapper.MapListProductDtoToListProduct(productsDto);
            
            return result;
        }
        
        public async Task<Product> UpdateProductAsync(Product prodcut)
        {
            var productDto = _mapper.MapProductToProductDto(prodcut);
            var callback = await ((ProductRepository)_productRepository).UpdateProductAsync(productDto);
            var result = _mapper.MapProductDtoToProduct(callback);

            return result;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var callback = await ((ProductRepository)_productRepository).DeleteProductAsync(id);
            var result = _mapper.MapProductDtoToProduct(callback);

            return result;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productsDto = await ((ProductRepository)_productRepository).GetProductByIdAsync(id);
            var result = _mapper.MapProductDtoToProduct(productsDto);

            return result;
        }

        public async Task<Tag> CreateTagAsync(Tag tag)
        {
            var tagDto = _mapper.MapTagToTagDto(tag);
            var callback = await ((ProductRepository)_productRepository).CreateTagAsync(tagDto);
            var result = _mapper.MapTagDtoToTag(callback);

            return result;
        }
        public async Task<ProductTag> AddProductTagAsync(int productId, int tagId)
        {
            var callback = await ((ProductRepository)_productRepository).AddProductTagAsync(productId, tagId);
            var result = _mapper.MapProductTagDtoToProductTag(callback);

            return result;
        }
        public async Task<IEnumerable<Tag>> GetAllTagsAsync(int? id)
        {
            var tagsDto = await ((ProductRepository)_productRepository).GetAllTagsAsync(id);
            var result = _mapper.MapListTagDtoToListTag(tagsDto);

            return result;
        }

        public async Task<IEnumerable<Product>> GetAllProductsByTagIdAsync(int id)
        {
            var productsDto = await ((ProductRepository)_productRepository).GetAllProductsByTagIdAsync(id);
            var result = _mapper.MapListProductDtoToListProduct(productsDto);

            return result;
        }
    }
}
