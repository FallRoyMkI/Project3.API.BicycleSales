
namespace BicycleSales.API.Models.AcceptanceProduct.Request
{
    public class AcceptanceProductUpdateRequest
    {
        public int ProductId { get; set; }
        public int AcceptanceId { get; set; }
        public int FactProductCount { get; set; }
    }
}
