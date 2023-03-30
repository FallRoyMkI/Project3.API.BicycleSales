using BicycleSales.BLL.Models.Acceptance.Response;
using BicycleSales.BLL.Models.Product.Response;


namespace BicycleSales.BLL.Models.AcceptanceProduct.Response
{
    public class AcceptanceProductResponse
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int FactProductCount { get; set; }
        public ProductResponse Product { get; set; }
        public AcceptanceResponse Acceptance { get; set; }
    }
}
