using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL;


namespace BicycleSales.BLL;

public class OrderManager : IOrderManager
{
    private readonly IMapperBLL _mapper;
    private readonly IOrderRepository _orderRepository;

    public OrderManager(IMapperBLL mapper = null, IOrderRepository orderRepository = null)
    {
        _mapper = mapper ?? new MapperBLL();
        _orderRepository = orderRepository ?? new OrderRepository();
    }

    public Order CreateAnOrder(Order order)
    {
        var dto = _mapper.MapOrderToOrderDto(order);
        var callback = _orderRepository.CreateAnOrder(dto);
        var result = _mapper.MapOrderDtoToOrder(callback);

        return result;
    }
    public Order EditOrderInfo(Order order)
    {
        var dto = _mapper.MapOrderToOrderDto(order);
        var callback = _orderRepository.EditOrderInfo(dto);
        var result = _mapper.MapOrderDtoToOrder(callback);

        return result;
    }

    public OrderProduct AddProductToOrder(OrderProduct orderProduct)
    {
        var dto = _mapper.MapOrderProductToOrderProductDto(orderProduct);
        var callback = _orderRepository.AddProductToOrder(dto);
        var result = _mapper.MapOrderProductDtoToOrderProduct(callback);

        return result;
    }
    public OrderProduct EditProductInOrder(OrderProduct orderProduct)
    {
        var dto = _mapper.MapOrderProductToOrderProductDto(orderProduct);
        var callback = _orderRepository.EditProductInOrder(dto);
        var result = _mapper.MapOrderProductDtoToOrderProduct(callback);

        return result;
    }

    public bool DeleteAnOrder(int orderId)
    {
       var result = _orderRepository.DeleteAnOrder(orderId);

       return result;
    }

    public List<Order> GetAllOrdersByShopId(int shopId)
    {
        var callback = _orderRepository.GetAllOrdersByShopId(shopId);
        var result = _mapper.MapOrderDtoListToOrderList(callback);

        return result.ToList();
    }

    public List<Order> GetAllOrdersWithProblems()
    {
        var callback = _orderRepository.GetAllOrdersWithProblems();
        var result = _mapper.MapOrderDtoListToOrderList(callback);

        return result.ToList();
    }
}