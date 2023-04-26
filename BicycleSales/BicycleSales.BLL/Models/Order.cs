using BicycleSales.Constants;

namespace BicycleSales.BLL.Models;

public class Order
{
    public int Id { get; set; }

    public string Name { get; set; }
    public DateTime DateOfCompilation { get; set; }
    public DateTime DateOfCompletion { get; set; }
    public OrderStatus Status { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int ShopId { get; set; }
    public Shop Shop { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Order order &&
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