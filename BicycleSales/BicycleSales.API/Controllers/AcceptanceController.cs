using BicycleSales.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BicycleSales.BLL.Models;
using BicycleSales.BLL;
using AutoMapper;
using BicycleSales.API.Models.Acceptance.Request;
using BicycleSales.API.Models.Acceptance.Response;
using BicycleSales.API.Models.AcceptanceProduct.Request;
using BicycleSales.API.Models.AcceptanceProduct.Response;

namespace BicycleSales.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AcceptanceController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAcceptanceManager _acceptanceManager;

    public AcceptanceController(IMapper mapper = null, IAcceptanceManager acceptanceManager = null)
    {
        _mapper = mapper; //?? new Mapper();
        _acceptanceManager = acceptanceManager ?? new AcceptanceManager();
    }

    [HttpPost("create-new-acceptance")]
    public IActionResult CreateNewAcceptance([FromBody] AcceptanceAddRequest acceptanceRequest)
    {
        try
        {
            var acceptance = _mapper.Map<Acceptance>(acceptanceRequest);
            var callback = _acceptanceManager.CreateNewAcceptance(acceptance);
            var result = _mapper.Map<AcceptanceResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }
    [HttpPut("update-acceptance")]
    public IActionResult UpdateAcceptance([FromQuery] AcceptanceUpdateRequest acceptanceRequest)
    {
        try
        {
            var acceptance = _mapper.Map<Acceptance>(acceptanceRequest);
            var callback = _acceptanceManager.UpdateAcceptance(acceptance);
            var result = _mapper.Map<AcceptanceResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }

    [HttpPost("add-products-to-acceptance")]
    public IActionResult AddProductToAcceptance([FromBody] AcceptanceProductAddRequest acceptanceProductRequest)
    {
        try
        {
            var acceptanceProduct = _mapper.Map<AcceptanceProduct>(acceptanceProductRequest);
            var callback = _acceptanceManager.AddProductToAcceptance(acceptanceProduct);
            var result = _mapper.Map<AcceptanceProductResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }
    [HttpPut("update-products-in-acceptance")]
    public IActionResult UpdateProductInAcceptance([FromQuery] AcceptanceProductUpdateRequest acceptanceProductRequest)
    {
        try
        {
            var acceptanceProduct = _mapper.Map<AcceptanceProduct>(acceptanceProductRequest);
            var callback = _acceptanceManager.UpdateProductInAcceptance(acceptanceProduct);
            var result = _mapper.Map<AcceptanceProductResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }

}