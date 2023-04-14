using BicycleSales.API.Models.Product.Request;
using BicycleSales.API.Models.Product.Response;
using BicycleSales.BLL;
using Microsoft.AspNetCore.Mvc;

namespace BicycleSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControler : ControllerBase
    {
        private readonly MapperAPI _mapper = new();

        [HttpGet(Name = "CreateNewProduct")]
        public ProductResponse CreateNewProduct(string name, int cost)
        {
            var productRequest = new ProductAddRequest()
            {
                Name = name,
                Cost = cost
            };

            var product = _mapper.MapProductAddRequestToProduct(productRequest);
            var callback = new ProductManager().CreateProduct(product);
            var result = _mapper.MapProductToProductResponse(callback);
            return result;
        }
    }
}
