namespace BicycleSales.BLL.Models
{
    public class AcceptanceProductDto
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int FactProductCount { get; set; }
        public ProductDto Product { get; set; }
        public AcceptanceDto Acceptance { get; set; }
    }
}
