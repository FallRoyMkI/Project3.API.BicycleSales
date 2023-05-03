using AutoMapper;
using BicycleSales.API.Models.Acceptance.Response;
using BicycleSales.API.Models.AcceptanceProduct.Response;
using BicycleSales.API.Models.ShipmentAcceptance.Request;
using BicycleSales.API.Models.ShipmentAcceptance.Response;
using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BicycleSales.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShipmentAcceptanceController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IShipmentAcceptanceManager _shipAccManager;

    public ShipmentAcceptanceController(IMapper mapper, IShipmentAcceptanceManager shipAccManager)
    {
        _mapper = mapper;
        _shipAccManager = shipAccManager;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateShipmentAcceptanceAsync([FromBody] ShipmentAcceptanceAddRequest shipmentAcceptanceAddRequest)
    {
        try
        {

            var shipmentAcceptance = _mapper.Map<ShipmentAcceptance>(shipmentAcceptanceAddRequest);
            if (shipmentAcceptanceAddRequest.FactoryId == 0)
            {
                shipmentAcceptance.FactoryId = null;
            }
            var callback = await _shipAccManager.CreateShipmentAcceptanceAsync(shipmentAcceptance);
            var result = _mapper.Map<ShipmentAcceptanceResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAcceptanceById([FromRoute] int id)
    {
        try
        {
            var callback = await _shipAccManager.GetShipmentAcceptanceById(id);
            var result = _mapper.Map<ShipmentAcceptance>(callback);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

