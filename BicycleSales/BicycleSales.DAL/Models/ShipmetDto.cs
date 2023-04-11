namespace BicycleSales.DAL.Models
{
    public class ShipmetDto
    {
        public int Id { get; set; }
        public DateTime PlanedTime { get; set; }
        public DateTime FactTime { get; set; }
        public UserDto FormedBy { get; set; }
        public UserDto SignedBy { get; set; }
        public ShopDto Shop { get; set; }
    }

    public class ShipmentProductDto
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int FactProductCount { get; set; }
        public ProductDto Product { get; set; }
        public ShipmetDto Shipment { get; set; }
    }
}
