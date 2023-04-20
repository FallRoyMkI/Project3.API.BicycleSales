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

        public ProductControler(IMapper mapper = null, IProductManager productManager = null)
        {
            _mapper = mapper; //?? new Mapper();
            _productManager = productManager ?? new ProductManager();
        }

        [HttpPost("create-product", Name = "CreateProduct")]
        public IActionResult CreateProduct(ProductAddRequest productAddRequest)
        {
            try
            {
                var product = _mapper.Map<Product>(productAddRequest);
                var callback = ((ProductManager)_productManager).CreateProduct(product);
                var result = _mapper.Map<ProductResponse>(callback);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("get-all-products", Name = "GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var listProducts = ((ProductManager)_productManager).GetAllProducts();
                var result = _mapper.Map<IEnumerable<ProductResponse>>(listProducts);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPut("update-product", Name = "UpdateProduct")]
        public IActionResult UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            var product = _mapper.Map<Product>(productUpdateRequest);
            var callback = ((ProductManager)_productManager).UpdateProduct(product);
            var result = _mapper.Map<ProductResponse>(callback);

            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var callback = ((ProductManager)_productManager).DeleteProduct(id);
                var result = _mapper.Map<ProductResponse>(callback);

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
                var product = ((ProductManager)_productManager).GetProductById(id);
                var result = _mapper.Map<ProductResponse>(product);

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
                var tag = _mapper.Map<Tag>(tagAddRequest);
                var callback = ((ProductManager)_productManager).CreateTag(tag);
                var result = _mapper.Map<TagResponse>(callback);

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
                var callback = ((ProductManager)_productManager).AddProductTag(productId, tagId);
                var result = _mapper.Map<ProductTagResponse>(callback);

                return Ok(result);
            }
            catch(Exception ex) 
            {
                return Ok(ex.Message);
            }
        }
    }
}
