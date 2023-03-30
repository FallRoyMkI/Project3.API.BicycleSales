
namespace BicycleSales.BLL.Models
{
    public class ShopProduct
    {
        public int ProductCount { get; set; }
        public Shop ShopId { get; set; }
        public Product Product { get; set; }
    }
}
