using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class OrderProductDto
{
    [Key]
    public int Id { get; set; }

    public int ProductCount { get; set; }
    public int ReadyProductCount { get; set; }

    public int OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public OrderDto Order { get; set; }

    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public ProductDto Product { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is OrderProductDto orderProduct &&
               Id == orderProduct.Id &&
               ProductCount == orderProduct.ProductCount &&
               ReadyProductCount == orderProduct.ReadyProductCount &&
               OrderId == orderProduct.OrderId &&
               Order.Equals(orderProduct.Order) &&
               ProductId == orderProduct.ProductId &&
               Product.Equals(orderProduct.Product);
    }
}