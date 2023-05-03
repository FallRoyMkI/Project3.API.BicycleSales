using AutoMapper;
using BicycleSales.API.Models.Shipment.Request;
using BicycleSales.API.Models.Shipment.Response;
using BicycleSales.API.Models.ShipmentAcceptance.Request;
using BicycleSales.API.Models.ShipmentAcceptance.Response;
using BicycleSales.API.Models.ShipmentProduct.Request;
using BicycleSales.API.Models.ShipmentProduct.Response;
using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.Constants;
using Microsoft.AspNetCore.Mvc;

namespace BicycleSales.API.Controllers;

[Route("[controller]/")]
[ApiController]
public class ShipmentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IShipmentManager _shipmentManager;

    public ShipmentController(IMapper mapper, IShipmentManager shipmentManager)
    {
        _mapper = mapper;
        _shipmentManager = shipmentManager;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateNewShipment([FromBody] ShipmentAddRequest shipmentRequest)
    {
        try
        {
            var shipment = _mapper.Map<Shipment>(shipmentRequest);
            var callback = await _shipmentManager.CreateNewShipment(shipment);
            var result = _mapper.Map<ShipmentResponse>(callback);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddProductToShipment([FromRoute] int id,
        [FromBody] ShipmentProductAddRequest shipmentProductRequest)
    {
        try
        {
            var shipmentProduct = _mapper.Map<ShipmentProduct>(shipmentProductRequest);
            shipmentProduct.ShipmentId = id;
            var callback = await _shipmentManager.AddProductToShipment(shipmentProduct);
            var result = _mapper.Map<ShipmentProductResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductInShipment([FromRoute] int id,
        [FromQuery] ShipmentProductUpdateRequest shipmentProductRequest)
    {
        try
        {
            var shipmentProduct = _mapper.Map<ShipmentProduct>(shipmentProductRequest);
            shipmentProduct.ShipmentId = id;
            var callback = await _shipmentManager.UpdateProductInShipment(shipmentProduct);
            var result = _mapper.Map<ShipmentProductResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("sign/{id}")]
    public async Task<IActionResult> UpdateShipment([FromRoute] int id,
       [FromQuery] ShipmentUpdateRequest shipmentRequest)
    {
        try
        {
            var shipment = _mapper.Map<Shipment>(shipmentRequest);
            shipment.Id = id;
            var callback = await _shipmentManager.UpdateShipment(shipment);
            var result = _mapper.Map<ShipmentResponse>(callback);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShipmentById([FromRoute] int id)
    {
        try
        {
            var callback = await _shipmentManager.GetShipmentById(id);
            var result = _mapper.Map<FullShipmentInfoResponse>(callback);

            var productsCallback = await _shipmentManager.GetAllProductFromShipmentById(id);
            var products = _mapper.Map<IEnumerable<ShipmentProductResponse>>(productsCallback);
            result.Products = products.ToList();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}















