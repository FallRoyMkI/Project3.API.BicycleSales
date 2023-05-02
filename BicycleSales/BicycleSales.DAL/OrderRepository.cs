using BicycleSales.DAL.Contexts;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleSales.DAL;

public class OrderRepository : IOrderRepository
{
    private readonly Context _context;

    public OrderRepository(Context context = null)
    {
        _context = context ?? new Context();
    }

    public OrderDto CreateAnOrder(OrderDto order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();

        return _context.Orders
            .Single(p => p.Id == order.Id);
    }

    public OrderDto EditOrderInfo(OrderDto order)
    {
        var update = _context.Orders.ToList().Find(x => x.Id == order.Id)!;

        update.DateOfCompletion = order.DateOfCompletion;
        update.Status = order.Status;

        _context.SaveChanges();
        return _context.Orders
            .Single(p => p.Id == order.Id); ;
    }

    public OrderProductDto AddProductToOrder(OrderProductDto orderProduct)
    {
        _context.OrdersProducts.Add(orderProduct);
        _context.SaveChanges();

        return _context.OrdersProducts
            .Single(p => p.Id == orderProduct.Id);
    }
    public OrderProductDto EditProductInOrder(OrderProductDto orderProduct)
    {
        var update = _context.OrdersProducts
            .Single(x => x.OrderId == orderProduct.OrderId &&
                         x.ProductId == orderProduct.ProductId);
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

    public OrderDto GetOrderById(int id)
    {
        return _context.Orders
            .Single(p => p.Id == id); ;
    }
    public OrderProductDto GetOrderProductByOrderAndProductId(int orderId, int productId)
    {
        return _context.OrdersProducts
            .Single(x => x.OrderId == orderId && x.ProductId == productId);
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

    public bool IsOrderExist(int id)
    {
        return _context.Orders.ToList().Exists(x => x.Id == id);
    }

    public bool IsProductExistInOrder(int orderId, int productId)
    {
        return _context.OrdersProducts.ToList().
            Exists(x => x.ProductId == productId && x.OrderId == orderId);
    }

    public bool IsOrderFinished(int id)
    {
        return _context.Orders.ToList().
            Exists(x => x.Id == id && (int)x.Status == 3);
    }

}