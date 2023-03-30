namespace BicycleSales.BLL.Models
{
    public class AcceptanceProduct
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int FactProductCount { get; set; }
        public Product Product { get; set; }
        public Acceptance Acceptance { get; set; }
    }
}
