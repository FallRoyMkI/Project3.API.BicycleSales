using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;

namespace BicycleSales.DAL;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context = null)
    {
        _context = context ?? new OrderContext();
    }

    public OrderDto CreateAnOrder(OrderDto order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
        return order;
    }
    public OrderDto EditOrderInfo(OrderDto order)
    {
        var update = _context.Orders.ToList().Find(x => x.Id == order.Id);
        if (update is not null)
        {
            update.DateOfCompletion = order.DateOfCompletion;
            update.Status = order.Status;
        }
        else
        {
            throw new ArgumentException("Cannot find order with such Id");
        }

        _context.SaveChanges();
        return update;
    }

    public OrderProductDto AddProductToOrder(OrderProductDto orderProduct)
    {
        _context.OrdersProducts.Add(orderProduct);
        _context.SaveChanges();
        return orderProduct;
    }
    public OrderProductDto EditProductInOrder(OrderProductDto orderProduct)
    {
        var update = _context.OrdersProducts.ToList().Find(x => x.Order.Id == orderProduct.Order.Id &&
                                                                x.Product.Id == orderProduct.Product.Id);
        if (update is not null)
        {
            update.ProductCount = orderProduct.ProductCount;
            update.ReadyProductCount = orderProduct.ReadyProductCount;
        }
        else
        {
            throw new ArgumentException("Cannot find order/product with such Id");
        }

        _context.SaveChanges();
        return update;
    }

    public bool DeleteAnOrder(int orderId)
    {
        var delete = _context.Orders.ToList().Find(x => x.Id == orderId);
        if (delete is null) throw new ArgumentException("Cannot find order with such Id");

        _context.Orders.ToList().Remove(delete);
        return true;
    }

    public List<OrderDto> GetAllOrdersByShopId(int shopId)
    {
        var result = _context.Orders.ToList().FindAll(x => x.Shop.Id == shopId);
        if (result.Count > 0)
        {
            return result;
        }
        throw new ArgumentException("Zero Orders in that shop");
    }

    public List<OrderDto> GetAllOrdersWithProblems()
    {
        var result = new List<OrderDto>();
        var temp = _context.OrdersProducts.ToList().FindAll(x => x.ReadyProductCount < x.ProductCount);
        if (temp.Count <= 0) throw new ArgumentException("Zero Orders with problems");

        foreach (var line in temp.Where(line => !result.Contains(result.Find(x => x.Id == line.Order.Id))))
        {
            result.Add(_context.Orders.ToList().Find(x => x.Id == line.Order.Id));
        }
        return result;
    }
}