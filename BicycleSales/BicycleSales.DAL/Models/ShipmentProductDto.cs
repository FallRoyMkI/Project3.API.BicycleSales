using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class ShipmentProductDto
{
    [Key]
    public int Id { get; set; }

    public int ProductCount { get; set; }
    public int FactProductCount { get; set; }

    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public ProductDto Product { get; set; }

    public int ShipmentId { get; set; }
    [ForeignKey(nameof(ShipmentId))]
    public ShipmentDto Shipment { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is ShipmentProductDto shipmentProduct &&
               Id == shipmentProduct.Id &&
               ProductCount == shipmentProduct.ProductCount &&
               FactProductCount == shipmentProduct.FactProductCount &&
               ProductId == shipmentProduct.ProductId &&
               Product.Equals(shipmentProduct.Product) &&
               ShipmentId == shipmentProduct.ShipmentId &&
               Shipment.Equals(shipmentProduct.Shipment);
    }
}