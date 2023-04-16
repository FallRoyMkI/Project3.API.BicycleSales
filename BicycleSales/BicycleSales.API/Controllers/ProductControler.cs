using BicycleSales.API.Models.Product.Request;
using BicycleSales.API.Models.Tag.Request;
using BicycleSales.BLL;
using Microsoft.AspNetCore.Mvc;


namespace BicycleSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControler : ControllerBase
    {
        private readonly MapperAPI _mapper = new MapperAPI();
        private readonly ProductManager _productManager = new ProductManager();

        [HttpPost("create-product", Name = "CreateProduct")]
        public IActionResult CreateProduct(ProductAddRequest productAddRequest)
        {
            try
            {
                var product = _mapper.MapProductAddRequestToProduct(productAddRequest);
                var callback = _productManager.CreateProduct(product);
                var result = _mapper.MapProductToProductResponse(callback);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("get-all-product", Name = "GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var listProducts = _productManager.GetAllProducts();
            var result = _mapper.MapListProductToListProductResponse(listProducts);

            return Ok(result);
        }

        [HttpPut("update-product", Name = "UpdateProduct")]
        public IActionResult UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            var product = _mapper.MapProductUpdateRequestToProduct(productUpdateRequest);
            var callback = _productManager.UpdateProduct(product);
            var result = _mapper.MapProductToProductResponse(callback);

            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var callback = _productManager.DeleteProduct(id);
                var result = _mapper.MapProductToProductResponse(callback);

                return Ok(result);
            }
            catch(Exception ex) 
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("get-product-{id}", Name = "GetProductById")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _productManager.GetProductById(id);
                var result = _mapper.MapProductToProductResponse(product);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("create-tag",Name = "CreateTag")]
        public IActionResult CreateTag(TagAddRequest tagAddRequest)
        {
            try
            {
                var tag = _mapper.MapTagAddRequestToTag(tagAddRequest);
                var callback = _productManager.CreateTag(tag);
                var result = _mapper.MapTagToTagResponse(callback);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost("add-productTag-{productId}-{tagId}", Name = "AddProductTag")]
        public IActionResult AddProductTag(int productId, int tagId)
        {
            try
            {
                var callback = _productManager.AddProductTag(productId, tagId);
                var result = _mapper.MapProductTagToProductTagResponse(callback);

                return Ok(result);
            }
            catch(Exception ex) 
            {
                return Ok(ex.Message);
            }
        }
    }
}
