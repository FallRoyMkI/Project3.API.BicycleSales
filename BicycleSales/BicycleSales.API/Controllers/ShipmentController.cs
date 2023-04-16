using BicycleSales.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BicycleSales.BLL.Models;
using BicycleSales.BLL;
using AutoMapper;
using BicycleSales.API.Models.Shipment.Request;
using BicycleSales.API.Models.Shipment.Response;
using BicycleSales.API.Models.ShipmentProduct.Request;
using BicycleSales.API.Models.ShipmentProduct.Response;

namespace BicycleSales.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShipmentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IShipmentManager _shipmentManager;

    public ShipmentController(IMapper mapper = null, IShipmentManager shipmentManager = null)
    {
        _mapper = mapper; //?? new Mapper();
        _shipmentManager = shipmentManager ?? new ShipmentManager();
    }

    [HttpPost("create-new-shipment")]
    public IActionResult CreateNewShipment([FromBody] ShipmentAddRequest shipmentRequest)
    {
        try
        {
            var shipment = _mapper.Map<Shipment>(shipmentRequest);
            var callback = _shipmentManager.CreateNewShipment(shipment);
            var result = _mapper.Map<ShipmentResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }
    [HttpPut("update-shipment")]
    public IActionResult UpdateShipment([FromQuery] ShipmentUpdateRequest shipmentRequest)
    {
        try
        {
            var shipment = _mapper.Map<Shipment>(shipmentRequest);
            var callback = _shipmentManager.UpdateShipment(shipment);
            var result = _mapper.Map<ShipmentResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }

    [HttpPost("add-products-to-shipment")]
    public IActionResult AddProductToShipment([FromBody] ShipmentProductAddRequest shipmentProductRequest)
    {
        try
        {
            var shipmentProduct = _mapper.Map<ShipmentProduct>(shipmentProductRequest);
            var callback = _shipmentManager.AddProductToShipment(shipmentProduct);
            var result = _mapper.Map<ShipmentProductResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }
    [HttpPut("update-products-in-shipment")]
    public IActionResult UpdateProductInShipment([FromQuery] ShipmentProductUpdateRequest shipmentProductRequest)
    {
        try
        {
            var shipmentProduct = _mapper.Map<ShipmentProduct>(shipmentProductRequest);
            var callback = _shipmentManager.UpdateProductInShipment(shipmentProduct);
            var result = _mapper.Map<ShipmentProductResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }

}