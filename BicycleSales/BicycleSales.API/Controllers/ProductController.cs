using AutoMapper;
using BicycleSales.API.Models.Product.Request;
using BicycleSales.API.Models.Product.Response;
using BicycleSales.API.Models.ProductTag.Request;
using BicycleSales.API.Models.Tag.Request;
using BicycleSales.API.Models.Tag.Response;
using BicycleSales.API.Validation;
using BicycleSales.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BicycleSales.BLL.Models;
using BicycleSales.BLL;
using AutoMapper;
using Azure.Core;
using BicycleSales.Constants.CustomExceptions.Product;
using BicycleSales.Constants.CustomExceptions.ProductTag;
using BicycleSales.Constants.CustomExceptions.Tag;
using FluentValidation;
using System.Net.WebSockets;

namespace BicycleSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductManager _productManager;
        private readonly ILogger<ProductController> _logger;
        private readonly ProductValidator _productValidator;

        public ProductController(ProductValidator productValidator, IMapper mapper = null, IProductManager productManager = null, ILogger<ProductController> logger = null)
        {
            _mapper = mapper; 
            _productManager = productManager ?? new ProductManager();
            _logger = logger;
            _productValidator = productValidator;
        }

        [HttpPost("create-product", Name = "CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductAddRequest productAddRequest)
        {
            try
            {
                var validationResult = _productValidator.Validate(productAddRequest);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                _logger.Log(LogLevel.Information, "Received a request to create a product");
                
                var product = _mapper.Map<Product>(productAddRequest);
                var callback = await ((ProductManager)_productManager).CreateProductAsync(product);
                var result = _mapper.Map<ProductResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the product when creating", result);
                
                return Ok(result);
            }
            catch(ProductException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
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
            catch (ProductException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-product", Name = "UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromQuery] ProductUpdateRequest productUpdateRequest)
        {
            try
            {
                ProductAddRequest productValidate = new ProductAddRequest() { Name = productUpdateRequest.Name, Cost = productUpdateRequest.Cost };
                var validationResult = _productValidator.Validate(productValidate);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                _logger.Log(LogLevel.Information, "Received a request to update a product");

                var product = _mapper.Map<Product>(productUpdateRequest);
                var callback = await ((ProductManager)_productManager).UpdateProductAsync(product);
                var result = _mapper.Map<ProductResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the product when updating", result);

                return Ok(result);
            }
            catch(ProductException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request to delete a product");

                var callback = await ((ProductManager)_productManager).DeleteProductAsync(id);
                var result = _mapper.Map<ProductResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the product when deleting", result);

                return Ok(result);
            }
            catch(ProductException ex) 
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-product-{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductByIdAsync([FromRoute] int id)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request for the get of product");

                var product = await ((ProductManager)_productManager).GetProductByIdAsync(id);
                var result = _mapper.Map<ProductResponse>(product);

                _logger.Log(LogLevel.Information, "Received the product upon request of get", result);

                return Ok(result);
            }
            catch (ProductException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-tag",Name = "CreateTag")]
        public async Task<IActionResult> CreateTagAsync([FromBody] TagAddRequest tagAddRequest)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request to create a tag");

                var tag = _mapper.Map<Tag>(tagAddRequest);
                var callback = await ((ProductManager)_productManager).CreateTagAsync(tag);
                var result = _mapper.Map<TagResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the tag when creating", result);

                return Ok(result);
            }
            catch(TagException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-productTag-{productId}-{tagId}", Name = "AddProductTag")]
        public async Task<IActionResult> AddProductTagAsync(int productId, int tagId)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request to add a productTag");

                var callback = await ((ProductManager)_productManager).AddProductTagAsync(productId, tagId);
                var result = _mapper.Map<ProductTagResponse>(callback);

                _logger.Log(LogLevel.Information, "Received the productTag when AddProductTagAsync", result);

                return Ok(result);
            }
            catch(ProductException ex) 
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
            catch (ProductTagException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
            catch (TagException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-tags-by-product-id", Name = "GetAllTagsByProductId")]
        public async Task<IActionResult> GetAllTagsByProductIdAsync( int? productId)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request for the get of tags");

                var listTags = await ((ProductManager)_productManager).GetAllTagsAsync(productId);
                var result = _mapper.Map<IEnumerable<TagResponse>>(listTags);

                _logger.Log(LogLevel.Information, "Received the tags upon request of GetAllTagsByProductIdAsync", result);

                return Ok(result);
            }
            catch (ProductException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
            catch (ProductTagException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
            catch (TagException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-products-by-{tagId}", Name = "GetAllProductsByTagIdAsync")]
        public async Task<IActionResult> GetAllProductsByTagIdAsync(int tagId)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Received a request for the get of products");

                var listProducts = await ((ProductManager)_productManager).GetAllProductsByTagIdAsync(tagId);
                var result = _mapper.Map<IEnumerable<ProductResponse>>(listProducts);

                _logger.Log(LogLevel.Information, "Received the products upon request of GetAllProductsByTagIdAsync", result);

                return Ok(result);
            }
            catch (ProductTagException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
            catch (TagException ex)
            {
                _logger.Log(LogLevel.Error, "Exception", ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
