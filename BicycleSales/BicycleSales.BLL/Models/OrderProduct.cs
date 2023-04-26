namespace BicycleSales.BLL.Models;

public class OrderProduct
{
    public int Id { get; set; }

    public int ProductCount { get; set; }
    public int ReadyProductCount { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is OrderProduct orderProduct &&
               Id == orderProduct.Id &&
               ProductCount == orderProduct.ProductCount &&
               ReadyProductCount == orderProduct.ReadyProductCount &&
               OrderId == orderProduct.OrderId &&
               Order.Equals(orderProduct.Order) &&
               ProductId == orderProduct.ProductId &&
               Product.Equals(orderProduct.Product);
    }
}