using AutoMapper;
using BicycleSales.API.Models.Acceptance.Request;
using BicycleSales.API.Models.Acceptance.Response;
using BicycleSales.API.Models.AcceptanceProduct.Request;
using BicycleSales.API.Models.AcceptanceProduct.Response;
using BicycleSales.API.Models.ShipmentAcceptance.Request;
using BicycleSales.API.Models.ShipmentAcceptance.Response;
using BicycleSales.BLL.Interfaces;
using BicycleSales.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BicycleSales.API.Controllers;

[Route("[controller]/")]
[ApiController]
public class AcceptanceController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAcceptanceManager _acceptanceManager;

    public AcceptanceController(IMapper mapper, IAcceptanceManager acceptanceManager)
    {
        _mapper = mapper;
        _acceptanceManager = acceptanceManager;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateNewAcceptance([FromBody] AcceptanceAddRequest acceptanceRequest)
    {
        try
        {
            var acceptance = _mapper.Map<Acceptance>(acceptanceRequest);
            var callback = await _acceptanceManager.CreateNewAcceptance(acceptance);
            var result = _mapper.Map<AcceptanceResponse>(callback);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddProductToAcceptance([FromRoute] int id,
        [FromBody] AcceptanceProductAddRequest acceptanceProductRequest)
    {
        try
        {
            var acceptanceProduct = _mapper.Map<AcceptanceProduct>(acceptanceProductRequest);
            acceptanceProduct.AcceptanceId = id;
            var callback = await _acceptanceManager.AddProductToAcceptance(acceptanceProduct);
            var result = _mapper.Map<AcceptanceProductResponse>(callback);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductInAcceptance([FromRoute] int id,
        [FromQuery] AcceptanceProductUpdateRequest acceptanceProductRequest)
    {
        try
        {
            var acceptanceProduct = _mapper.Map<AcceptanceProduct>(acceptanceProductRequest);
            acceptanceProduct.AcceptanceId = id;
            var callback = await _acceptanceManager.UpdateProductInAcceptance(acceptanceProduct);
            var result = _mapper.Map<AcceptanceProductResponse>(callback);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("sign/{id}")]
    public async Task<IActionResult> UpdateAcceptance([FromRoute] int id,
        [FromQuery] AcceptanceUpdateRequest acceptanceRequest)
    {
        try
        {
            var acceptance = _mapper.Map<Acceptance>(acceptanceRequest);
            acceptance.Id = id;
            var callback = await _acceptanceManager.UpdateAcceptance(acceptance);
            var result = _mapper.Map<AcceptanceResponse>(callback);

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
            var callback = await _acceptanceManager.GetAcceptanceById(id);
            var result = _mapper.Map<FullAcceptanceInfoResponse>(callback);

            var productsCallback = await _acceptanceManager.GetAllProductFromAcceptanceById(id);
            var products = _mapper.Map<IEnumerable<AcceptanceProductResponse>>(productsCallback);
            result.Products = products.ToList();

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}