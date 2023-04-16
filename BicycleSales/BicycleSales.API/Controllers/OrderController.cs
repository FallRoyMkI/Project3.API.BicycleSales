using BicycleSales.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BicycleSales.BLL.Models;
using BicycleSales.BLL;
using AutoMapper;
using BicycleSales.API.Models.Order.Request;
using BicycleSales.API.Models.Order.Response;
using BicycleSales.API.Models.OrderProduct.Request;
using BicycleSales.API.Models.OrderProduct.Response;

namespace BicycleSales.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOrderManager _orderManager;

    public OrderController(IMapper mapper = null, IOrderManager orderManager = null)
    {
        _mapper = mapper; //?? new Mapper();
        _orderManager = orderManager ?? new OrderManager();
    }

    [HttpPost("create-new-order")]
    public IActionResult CreateAnOrder([FromBody] OrderAddRequest orderRequest)
    {
        try
        {
            var order = _mapper.Map<Order>(orderRequest);
            var callback = _orderManager.CreateAnOrder(order);
            var result = _mapper.Map<OrderResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }
    [HttpPut("update-an-order")]
    public IActionResult EditOrderInfo([FromQuery] OrderUpdateRequest orderRequest)
    {
        try
        {
            var order = _mapper.Map<Order>(orderRequest);
            var callback = _orderManager.EditOrderInfo(order);
            var result = _mapper.Map<OrderResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }

    [HttpPost("add-products-to-order")]
    public IActionResult AddProductToOrder([FromBody] OrderProductAddRequest orderProductRequest)
    {
        try
        {
            var orderProduct = _mapper.Map<OrderProduct>(orderProductRequest);
            var callback = _orderManager.AddProductToOrder(orderProduct);
            var result = _mapper.Map<OrderProductResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }

    [HttpPut("update-products-in-order")]
    public IActionResult EditProductInOrder([FromQuery] OrderProductUpdateRequest orderProductRequest)
    {
        try
        {
            var orderProduct = _mapper.Map<OrderProduct>(orderProductRequest);
            var callback = _orderManager.EditProductInOrder(orderProduct);
            var result = _mapper.Map<OrderProductResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }

    [HttpDelete("delete-an-order")]
    public IActionResult DeleteAnOrder([FromQuery] int orderId)
    {
        try
        {
            var result = _orderManager.DeleteAnOrder(orderId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }

    [HttpGet("get-all-orders-in-shop-{id}")]
    public IActionResult GetAllOrdersByShopId([FromRoute] int shopId)
    {
        try
        {
            var callback = _orderManager.GetAllOrdersByShopId(shopId);
            var result = _mapper.Map<List<OrderResponse>>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }

    [HttpGet("get-all-orders-with-problems")]
    public IActionResult GetAllOrdersWithProblems()
    {
        try
        {
            var callback = _orderManager.GetAllOrdersWithProblems();
            var result = _mapper.Map<List<OrderResponse>>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }
}