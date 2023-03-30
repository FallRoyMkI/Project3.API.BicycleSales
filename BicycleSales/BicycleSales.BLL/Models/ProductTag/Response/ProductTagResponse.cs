using BicycleSales.BLL.Models.Product.Response;
using BicycleSales.BLL.Models.Tag.Response;

namespace BicycleSales.BLL.Models.ProductTag.Response
{
    public class ProductTagResponse
    {
        public ProductResponse Product { get; set; }
        public TagResponse Tag { get; set; }
    }
}
