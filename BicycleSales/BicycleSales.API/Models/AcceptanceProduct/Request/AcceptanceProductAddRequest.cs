
namespace BicycleSales.API.Models.AcceptanceProduct.Request
{
    public class AcceptanceProductAddRequest
    {
        public int ProductCount { get; set; }
        public int ProductId { get; set; }
        public int AcceptanceId { get; set; }
    }
}
