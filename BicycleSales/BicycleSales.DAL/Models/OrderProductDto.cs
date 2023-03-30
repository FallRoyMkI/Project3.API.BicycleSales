namespace BicycleSales.BLL.Models
{
    public class OrderProductDto
    {
        public int ProductCount { get; set; }
        public int ReadyProductCount { get; set; }
        public OrderDto Order { get; set; }
        public ProductDto Product { get; set; }
    }
}
