using BicycleSales.API.Models.Product.Response;

namespace BicycleSales.API.Models.ProductTag.Request
{
    public class ProductTagRequest
    {
        public int ProductId { get; set; }
        public int TagId { get; set; }
    }
}
