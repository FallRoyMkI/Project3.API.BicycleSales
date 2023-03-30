
namespace BicycleSales.BLL.Models
{
    public class ShipmentProduct
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int FactProductCount { get; set; }
        public Product Product { get; set; }
        public Shipmet Shipment { get; set; }
    }
}
