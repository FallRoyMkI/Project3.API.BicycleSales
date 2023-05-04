using AutoMapper;
using BicycleSales.API.Models.Order.Request;
using BicycleSales.API.Models.Order.Response;
using BicycleSales.API.Models.OrderProduct.Request;
using BicycleSales.API.Models.OrderProduct.Response;
using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BicycleSales.API.Controllers;

[Route("[controller]/")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOrderManager _orderManager;

    public OrderController(IMapper mapper, IOrderManager orderManager)
    {
        _mapper = mapper;
        _orderManager = orderManager;
    }

    [HttpPost("")]
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
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}/status")]
    public IActionResult EditOrderInfo([FromRoute] int id,
        [FromQuery] OrderUpdateRequest orderRequest)
    {
        try
        {
            var order = _mapper.Map<Order>(orderRequest);
            order.Id = id;
            var callback = _orderManager.EditOrderInfo(order);
            var result = _mapper.Map<OrderResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddProductToOrder([FromRoute] int id,
        [FromBody] OrderProductAddRequest orderProductRequest)
    {
        try
        {
            var orderProduct = _mapper.Map<OrderProduct>(orderProductRequest);
            orderProduct.OrderId = id;
            var callback = await _orderManager.AddProductToOrder(orderProduct);
            var result = _mapper.Map<OrderProductResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditProductInOrder([FromRoute] int id,
        [FromQuery] OrderProductUpdateRequest orderProductRequest)
    {
        try
        {
            var orderProduct = _mapper.Map<OrderProduct>(orderProductRequest);
            orderProduct.OrderId = id;
            var callback = await _orderManager.EditProductInOrder(orderProduct);
            var result = _mapper.Map<OrderProductResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnOrder([FromRoute] int orderId)
    {
        try
        {
            var result = _orderManager.DeleteAnOrder(orderId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/orders")]
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
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("problems")]
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
            return BadRequest(ex.Message);
        }
    }
}