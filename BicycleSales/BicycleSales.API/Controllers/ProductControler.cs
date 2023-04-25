using AutoMapper;
using BicycleSales.API.Models.Product.Request;
using BicycleSales.API.Models.Product.Response;
using BicycleSales.API.Models.ProductTag.Request;
using BicycleSales.API.Models.Tag.Request;
using BicycleSales.API.Models.Tag.Response;
using BicycleSales.BLL;
using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using Microsoft.AspNetCore.Mvc;


namespace BicycleSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControler : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductManager _productManager;
        private readonly ILogger<ProductControler> _logger;

        public ProductControler(IMapper mapper = null, IProductManager productManager = null, ILogger<ProductControler> logger = null)
        {
            _mapper = mapper; //?? new Mapper();
            _productManager = productManager ?? new ProductManager();
            _logger = logger;
        }

        [HttpPost("create-product", Name = "CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductAddRequest productAddRequest)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request to create a product");
                
                var product = _mapper.Map<Product>(productAddRequest);
                var callback = await ((ProductManager)_productManager).CreateProduct(product);
                var result = _mapper.Map<ProductResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the product when creating", result);
                
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }

        [HttpGet("get-all-products", Name = "GetAllProducts")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request for the get of products");

                var listProducts = await ((ProductManager)_productManager).GetAllProductsAsync();
                var result = _mapper.Map<IEnumerable<ProductResponse>>(listProducts);

                _logger.Log(LogLevel.Information, "Received the products upon request of get", result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }

        [HttpPut("update-product", Name = "UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request to update a product");

                var product = _mapper.Map<Product>(productUpdateRequest);
                var callback = await ((ProductManager)_productManager).UpdateProduct(product);
                var result = _mapper.Map<ProductResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the product when updating", result);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request to delete a product");

                var callback = await ((ProductManager)_productManager).DeleteProduct(id);
                var result = _mapper.Map<ProductResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the product when deleting", result);

                return Ok(result);
            }
            catch(Exception ex) 
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }

        [HttpGet("get-product-{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request for the get of product");

                var product = await ((ProductManager)_productManager).GetProductById(id);
                var result = _mapper.Map<ProductResponse>(product);

                _logger.Log(LogLevel.Information, "Received the product upon request of get", result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }

        [HttpPost("create-tag",Name = "CreateTag")]
        public async Task<IActionResult> CreateTag(TagAddRequest tagAddRequest)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request to create a tag");

                var tag = _mapper.Map<Tag>(tagAddRequest);
                var callback = await ((ProductManager)_productManager).CreateTag(tag);
                var result = _mapper.Map<TagResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the tag when creating", result);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }

        [HttpPost("add-productTag-{productId}-{tagId}", Name = "AddProductTag")]
        public async Task<IActionResult> AddProductTag(int productId, int tagId)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request to add a productTag");

                var callback = await ((ProductManager)_productManager).AddProductTag(productId, tagId);
                var result = _mapper.Map<ProductTagResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the productTag when adding", result);

                return Ok(result);
            }
            catch(Exception ex) 
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return Ok(ex.Message);
            }
        }
    }
}
