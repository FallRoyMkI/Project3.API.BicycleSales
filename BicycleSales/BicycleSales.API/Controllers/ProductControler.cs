using AutoMapper;
using BicycleSales.API.Models.Product.Request;
using BicycleSales.API.Models.Product.Response;
using BicycleSales.BLL;
using BicycleSales.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BicycleSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControler : ControllerBase
    {
        private readonly MapperAPI _mapper = new MapperAPI();
        private readonly ProductManager _productManager = new ProductManager();

        [HttpPost]
        public IActionResult CreateProduct(ProductAddRequest productAddRequest)
        {
            var product = _mapper.MapProductAddRequestToProduct(productAddRequest);
            var callback = _productManager.CreateProduct(product);
            var result = _mapper.MapProductToProductResponse(callback);

            return Ok(result);
        }

        [HttpGet(Name = "GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var listProducts = _productManager.GetAllProducts();
            var result = _mapper.MapListProductToListProductResponse(listProducts);

            return Ok(result);
        }
    }
}
