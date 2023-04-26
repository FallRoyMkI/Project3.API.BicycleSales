namespace BicycleSales.BLL.Models;

public class ShipmentProduct
{
    public int Id { get; set; }

    public int ProductCount { get; set; }
    public int FactProductCount { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int ShipmentId { get; set; }
    public Shipment Shipment { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is ShipmentProduct shipmentProduct &&
               Id == shipmentProduct.Id &&
               ProductCount == shipmentProduct.ProductCount &&
               FactProductCount == shipmentProduct.FactProductCount &&
               ProductId == shipmentProduct.ProductId &&
               Product.Equals(shipmentProduct.Product) &&
               ShipmentId == shipmentProduct.ShipmentId &&
               Shipment.Equals(shipmentProduct.Shipment);
    }
}