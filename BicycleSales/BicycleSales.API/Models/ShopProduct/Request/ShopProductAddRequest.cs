
namespace BicycleSales.API.Models.ShopProduct.Request
{
    public class ShopProductAddRequest
    {
        public int ProductCount { get; set; }
        public int ShopId { get; set; }
        public int ProductId { get; set; }
    }
}
