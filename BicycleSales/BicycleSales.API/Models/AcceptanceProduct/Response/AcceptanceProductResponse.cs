using BicycleSales.API.Models.Acceptance.Response;
using BicycleSales.API.Models.Product.Response;

namespace BicycleSales.API.Models.AcceptanceProduct.Response
{
    public class AcceptanceProductAddRequest
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int FactProductCount { get; set; }
        public ProductAddRequest Product { get; set; }
        public AcceptanceAddRequest Acceptance { get; set; }
    }
}
