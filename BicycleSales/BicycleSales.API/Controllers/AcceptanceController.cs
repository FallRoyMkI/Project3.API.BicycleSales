using BicycleSales.API.Models.AcceptanceProduct.Response;
using BicycleSales.API.Models.AcceptanceProduct.Request;
using BicycleSales.API.Models.Acceptance.Response;
using BicycleSales.API.Models.Acceptance.Request;
using BicycleSales.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BicycleSales.BLL.Models;
using BicycleSales.Constants;
using BicycleSales.BLL;
using AutoMapper;

namespace BicycleSales.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AcceptanceController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAcceptanceManager _acceptanceManager;

    public AcceptanceController(IMapper mapper = null, IAcceptanceManager acceptanceManager = null)
    {
        _mapper = mapper;
        _acceptanceManager = acceptanceManager ?? new AcceptanceManager();
    }

    [HttpPost("create-new-acceptance")]
    public async Task<IActionResult> CreateNewAcceptance([FromBody] AcceptanceAddRequest acceptanceRequest)
    {
        try
        {
            var acceptance = _mapper.Map<Acceptance>(acceptanceRequest);
            var callback = await _acceptanceManager.CreateNewAcceptance(acceptance);
            var result = _mapper.Map<AcceptanceResponse>(callback);

            return Ok(result);
        }
        catch (ObjectNotExistException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (InvalidTimeException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (Exception ex)
        {
            return Ok("ЧТОТО ПОШЛО НЕ ТАК");
        }
    }

    [HttpPost("add-products-to-acceptance")]
    public async Task<IActionResult> AddProductToAcceptance([FromBody] AcceptanceProductAddRequest acceptanceProductRequest)
    {
        try
        {
            var acceptanceProduct = _mapper.Map<AcceptanceProduct>(acceptanceProductRequest);
            var callback = await _acceptanceManager.AddProductToAcceptance(acceptanceProduct);
            var result = _mapper.Map<AcceptanceProductResponse>(callback);

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


    [HttpPut("update-products-in-acceptance")]
    public async Task<IActionResult> UpdateProductInAcceptance([FromQuery] AcceptanceProductUpdateRequest acceptanceProductRequest)
    {
        try
        {
            var acceptanceProduct = _mapper.Map<AcceptanceProduct>(acceptanceProductRequest);
            var callback = await _acceptanceManager.UpdateProductInAcceptance(acceptanceProduct);
            var result = _mapper.Map<AcceptanceProductResponse>(callback);

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

    [HttpPut("update-acceptance")]
    public async Task<IActionResult> UpdateAcceptance([FromQuery] AcceptanceUpdateRequest acceptanceRequest)
    {
        try
        {
            var acceptance = _mapper.Map<Acceptance>(acceptanceRequest);
            var callback = await _acceptanceManager.UpdateAcceptance(acceptance);
            var result = _mapper.Map<AcceptanceResponse>(callback);

            return Ok(result);
        }
        catch (ObjectNotExistException ex)
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

    [HttpGet("get-acceptance-{id}")]
    public async Task<IActionResult> GetAcceptanceById([FromRoute] int id)
    {
        try
        {
            var callback = await _acceptanceManager.GetAcceptanceById(id);
            var result = _mapper.Map<FullAcceptanceInfoResponse>(callback);

            var productsCallback = await _acceptanceManager.GetAllProductFromAcceptanceById(id);
            var products = _mapper.Map<IEnumerable<AcceptanceProductLowInfoResponse>>(productsCallback);
            result.Products = products.ToList(); 

            return Ok(result);
        }
        catch (ObjectNotExistException ex)
        {
            return Ok($"{ex.Message}");
        }
    }
}