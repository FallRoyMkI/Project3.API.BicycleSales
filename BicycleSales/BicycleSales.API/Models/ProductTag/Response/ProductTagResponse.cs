using BicycleSales.API.Models.Product.Response;
using BicycleSales.API.Models.Tag.Response;

namespace BicycleSales.API.Models.ProductTag.Request
{
    public class ProductTagResponse
    {
        public ProductResponse Product { get; set; }
        public TagResponse Tag { get; set; }
    }
}
