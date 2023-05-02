using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.Constants;
using BicycleSales.DAL.Interfaces;
using BicycleSales.DAL;
using BicycleSales.DAL.Models;


namespace BicycleSales.BLL;

public class OrderManager : IOrderManager
{
    private readonly IMapperBLL _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IShopRepository _shopRepository;

    public OrderManager(IMapperBLL mapper, IOrderRepository orderRepository, 
        IProductRepository productRepository, IUserRepository userRepository, IShopRepository shopRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _userRepository = userRepository;
        _shopRepository = shopRepository;
    }

    public Order CreateAnOrder(Order order)
    {
        if (!_userRepository.IsUserExist(order.UserId))
            throw new ObjectNotExistException("User", order.UserId);
        if (!_shopRepository.IsShopExist(order.ShopId))
            throw new ObjectNotExistException("Shop", order.ShopId);

        var dto = _mapper.MapOrderToOrderDto(order);
        dto.DateOfCompilation = DateTime.Now;
        var callback = _orderRepository.CreateAnOrder(dto);
        var result = _mapper.MapOrderDtoToOrder(callback);

        return result;
    }
    public Order EditOrderInfo(Order order)
    {
        if (!_orderRepository.IsOrderExist(order.Id))
            throw new ObjectNotExistException("Order", order.Id);
        if (_orderRepository.IsOrderFinished(order.Id))
            throw new WorkWithForbiddenResourceException("Order", order.Id);
        if (order.Status == OrderStatus.OrderFinished) order.DateOfCompletion = DateTime.Now;
        if ((int)order.Status < 0 || (int)order.Status > 5) 
            throw new ObjectNotExistException("Status", (int)order.Status);

        var dto = _mapper.MapOrderToOrderDto(order);
        var callback = _orderRepository.EditOrderInfo(dto);
        var result = _mapper.MapOrderDtoToOrder(callback);

        return result;
    }

    public async Task<OrderProduct> AddProductToOrder(OrderProduct orderProduct)
    {
        if (!_orderRepository.IsOrderExist(orderProduct.OrderId))
            throw new ObjectNotExistException("Order", orderProduct.OrderId);
        if (!_productRepository.IsProductExist(orderProduct.ProductId))
            throw new ObjectNotExistException("Product", orderProduct.ProductId);
        if (orderProduct.ProductCount < 1)
            throw new ArgumentOutOfRangeException("", "Product count must be positive");
        if (_orderRepository.IsProductExistInOrder(orderProduct.OrderId, orderProduct.ProductId))
            throw new RepetativeActionException("Adding", "Product");

        var dto = _mapper.MapOrderProductToOrderProductDto(orderProduct);
        var callback = _orderRepository.AddProductToOrder(dto);
        var result = _mapper.MapOrderProductDtoToOrderProduct(callback);

        return result;
    }
    public async Task<OrderProduct> EditProductInOrder(OrderProduct orderProduct)
    {
        if (!_orderRepository.IsOrderExist(orderProduct.OrderId))
            throw new ObjectNotExistException("Order", orderProduct.OrderId);
        if (!_productRepository.IsProductExist(orderProduct.ProductId))
            throw new ObjectNotExistException("Product", orderProduct.ProductId);

        var order = _orderRepository.GetOrderById(orderProduct.OrderId);
        var orderProductDb = _orderRepository.GetOrderProductByOrderAndProductId(order.Id, orderProduct.ProductId);

        if (orderProductDb.ProductCount == orderProductDb.ReadyProductCount)
            throw new WorkWithForbiddenResourceException("Order Product", orderProductDb.Id);

        var shopProductsDB = await ((ShopRepository)_shopRepository).GetAllProductsByShopId(order.ShopId);
        var currentProductInShop = shopProductsDB.ToList().Find(x => x.Id == orderProduct.ProductId);
        var difference =  orderProductDb.ProductCount - orderProduct.ReadyProductCount;
        if (difference > 0)
        {
            if (difference <= currentProductInShop.ProductCount)
            {
                orderProductDb.ReadyProductCount = orderProductDb.ProductCount;
                var remove = new ShopProductDto()
                {
                    Id = currentProductInShop.Id,
                    Product = currentProductInShop.Product,
                    ProductCount = difference,
                    ProductId = currentProductInShop.ProductId,
                    Shop = currentProductInShop.Shop,
                    ShopId = currentProductInShop.ShopId,
                };

                _shopRepository.DeleteProductCountInShopAsync(remove);
            }
            else
            {
                orderProductDb.ReadyProductCount = currentProductInShop.ProductCount;

                var remove = new ShopProductDto()
                {
                    Id = currentProductInShop.Id,
                    Product = currentProductInShop.Product,
                    ProductCount = currentProductInShop.ProductCount,
                    ProductId = currentProductInShop.ProductId,
                    Shop = currentProductInShop.Shop,
                    ShopId = currentProductInShop.ShopId,
                };

                
                _shopRepository.DeleteProductCountInShopAsync(remove);
                order.Status = OrderStatus.RequiredProductSupply;
            }
            _orderRepository.EditOrderInfo(order);
            _orderRepository.EditProductInOrder(orderProductDb);
        }

        var callback = _orderRepository.EditProductInOrder(orderProductDb);
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