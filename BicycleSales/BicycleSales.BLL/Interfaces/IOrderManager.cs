using BicycleSales.BLL.Models;

namespace BicycleSales.BLL.Interfaces;

public interface IOrderManager
{
    public Order CreateAnOrder(Order order);
    public Order EditOrderInfo(Order order);

    public OrderProduct AddProductToOrder(OrderProduct orderProduct);
    public OrderProduct EditProductInOrder(OrderProduct orderProduct);

    public bool DeleteAnOrder(int orderId);

    public List<Order> GetAllOrdersByShopId(int shopId);

    public List<Order> GetAllOrdersWithProblems();
}