namespace BicycleSales.BLL.Models
{
    public class OrderProduct
    {
        public int ProductCount { get; set; }
        public int ReadyProductCount { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
