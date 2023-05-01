using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BicycleSales.Constants;

namespace BicycleSales.DAL.Models;

public class OrderDto
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfCompilation { get; set; }
    public DateTime? DateOfCompletion { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.OrderCreated;

    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public UserDto User { get; set; }

    public int ShopId { get; set; }
    [ForeignKey(nameof(ShopId))]
    public ShopDto Shop { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is OrderDto order &&
               Id == order.Id &&
               Name == order.Name &&
               DateOfCompilation == order.DateOfCompilation &&
               DateOfCompletion == order.DateOfCompletion &&
               Status == order.Status &&
               UserId == order.UserId &&
               User.Equals(order.User) &&
               ShopId == order.ShopId &&
               Shop.Equals(order.Shop);
    }
}