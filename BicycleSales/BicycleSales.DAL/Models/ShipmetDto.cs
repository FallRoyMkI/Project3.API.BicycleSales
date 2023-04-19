using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleSales.DAL.Models
{
    public class ShipmentDto
    {
        [Key]
        public int Id { get; set; }
        public DateTime PlanedTime { get; set; }
        public DateTime FactTime { get; set; }

        public int FormedById { get; set; }

        //[ForeignKey(nameof(FormedById))]
        public UserDto FormedBy { get; set; }

        public int SignedById { get; set; }

        //[ForeignKey(nameof(SignedById))]
        public UserDto SignedBy { get; set; }

        public int ShopId { get; set; }

        //[ForeignKey(nameof(ShopId))]
        public ShopDto Shop { get; set; }
    }

    public class ShipmentProductDto
    {
        [Key]
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int FactProductCount { get; set; }

        public int ProductId { get; set; }

        //[ForeignKey(nameof(ProductId))]
        public ProductDto Product { get; set; }

        public int ShipmentId { get; set; }

        //[ForeignKey(nameof(ShipmentId))]
        public ShipmentDto Shipment { get; set; }
    }
}
