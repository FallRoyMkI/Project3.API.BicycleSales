namespace BicycleSales.API.Models.Product.Request
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
