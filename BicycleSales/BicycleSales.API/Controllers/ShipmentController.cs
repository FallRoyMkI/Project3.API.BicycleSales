using AutoMapper;
using BicycleSales.API.Models.Acceptance.Request;
using BicycleSales.API.Models.Acceptance.Response;
using BicycleSales.API.Models.AcceptanceProduct.Response;
using BicycleSales.API.Models.Shipment.Request;
using BicycleSales.API.Models.Shipment.Response;
using BicycleSales.API.Models.ShipmentAcceptance.Request;
using BicycleSales.API.Models.ShipmentAcceptance.Response;
using BicycleSales.API.Models.ShipmentProduct.Request;
using BicycleSales.API.Models.ShipmentProduct.Response;
using BicycleSales.BLL;
using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using BicycleSales.Constants;
using Microsoft.AspNetCore.Mvc;

namespace BicycleSales.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShipmentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IShipmentManager _shipmentManager;

    public ShipmentController(IMapper mapper = null, IShipmentManager shipmentManager = null)
    {
        _mapper = mapper;
        _shipmentManager = shipmentManager ?? new ShipmentManager();
    }

    [HttpPost("create-new-shipment")]
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

    [HttpPost("add-products-to-shipment")]
    public async Task<IActionResult> AddProductToShipment([FromBody] ShipmentProductAddRequest shipmentProductRequest)
    {
        try
        {
            var shipmentProduct = _mapper.Map<ShipmentProduct>(shipmentProductRequest);
            var callback = await _shipmentManager.AddProductToShipment(shipmentProduct);
            var result = _mapper.Map<ShipmentProductResponse>(callback);
            return Ok(result);
        }
        catch (ObjectNotExistException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (RepetativeActionException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (Exception ex)
        {
            return Ok("ЧТОТО ПОШЛО НЕ ТАК");
        }
    }

    [HttpPut("update-products-in-shipment")]
    public async Task<IActionResult> UpdateProductInShipment([FromQuery] ShipmentProductUpdateRequest shipmentProductRequest)
    {
        try
        {
            var shipmentProduct = _mapper.Map<ShipmentProduct>(shipmentProductRequest);
            var callback = await _shipmentManager.UpdateProductInShipment(shipmentProduct);
            var result = _mapper.Map<ShipmentProductResponse>(callback);
            return Ok(result);
        }
        catch (ObjectNotExistException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (RepetativeActionException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (Exception ex)
        {
            return Ok("ЧТОТО ПОШЛО НЕ ТАК");
        }
    }

    [HttpPut("shipment/{id}")]
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
     
    [HttpGet("get-shipment-{id}")]
    public async Task<IActionResult> GetShipmentById([FromRoute] int id)
    {
        try
        {
            var callback = await _shipmentManager.GetShipmentById(id);
            var result = _mapper.Map<FullShipmentInfoResponse>(callback);

            var productsCallback = await _shipmentManager.GetAllProductFromShipmentById(id);
            var products = _mapper.Map<IEnumerable<ShipmentProductLowInfoResponse>>(productsCallback);
            result.Products = products.ToList();

            return Ok(result);
        }
        catch (ObjectNotExistException ex)
        {
            return Ok($"{ex.Message}");
        }
    }

    [HttpPost("create-shipment-acceptance")]
    public async Task<IActionResult> CreateShipmentAcceptanceAsync([FromBody] ShipmentAcceptanceAddRequest ShipmentAcceptanceAddRequest)
    {
        try
        {
            var shipmentAcceptance = _mapper.Map<ShipmentAcceptance>(ShipmentAcceptanceAddRequest);
            var callback = await _shipmentManager.CreateShipmentAcceptanceAsync(shipmentAcceptance);
            var result = _mapper.Map<ShipmentAcceptanceResponse>(callback);
            return Ok(result);
        }
        catch (ObjectNotExistException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (RepetativeActionException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (Exception ex)
        {
            return Ok("ЧТОТО ПОШЛО НЕ ТАК");
        }
    }

}















