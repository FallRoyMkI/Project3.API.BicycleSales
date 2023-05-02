using BicycleSales.DAL.Models;

namespace BicycleSales.DAL.Interfaces;

public interface IOrderRepository
{
    public OrderDto CreateAnOrder(OrderDto order);
    public OrderDto EditOrderInfo(OrderDto order);

    public OrderProductDto AddProductToOrder(OrderProductDto orderProduct);
    public OrderProductDto EditProductInOrder(OrderProductDto orderProduct);

    public bool DeleteAnOrder(int orderId);

    public List<OrderDto> GetAllOrdersByShopId(int shopId);
    public OrderDto GetOrderById(int id);
    public OrderProductDto GetOrderProductByOrderAndProductId(int orderId, int productId);
    public List<OrderDto> GetAllOrdersWithProblems();
    public bool IsOrderExist(int id);
    public bool IsProductExistInOrder(int orderId, int productId);
    public bool IsOrderFinished(int id);
}