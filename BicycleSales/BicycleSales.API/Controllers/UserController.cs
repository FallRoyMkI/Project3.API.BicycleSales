using BicycleSales.API.Models.AuthorizationProduct.Response;
using BicycleSales.API.Models.AuthorizationProduct.Request;
using BicycleSales.API.Models.User.Response;
using BicycleSales.API.Models.User.Request;
using BicycleSales.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BicycleSales.BLL.Models;
using BicycleSales.Constants;
using BicycleSales.BLL;
using AutoMapper;

namespace BicycleSales.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserManager _userManager;

    public UserController(IMapper mapper = null, IUserManager userManager = null)
    {
        _mapper = mapper; 
        _userManager = userManager ?? new UserManager();
    }

    [HttpPost("create-new-account")]
    public IActionResult CreateNewAccount([FromBody] AuthorizationAddRequest authorizationRequest)
    {
        try
        {
            var auth = _mapper.Map<Authorization>(authorizationRequest);
            auth.Status = UserStatus.CommonUser;
            var callback = _userManager.CreateAnAccount(auth);
            var result = _mapper.Map<AuthorizationResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok(ex.Message == "Login already exist" ? "ЛОГИН ЗАНЯТ" : "ЧТОТО ПОШЛО НЕ ТАК");
        }
    }

    [HttpPut("update-an-account")]
    public IActionResult UpdateAuthorization([FromQuery] AuthorizationUpdateRequest authorizationRequest)
    {
        try
        {
            var auth = _mapper.Map<Authorization>(authorizationRequest);
            var callback = _userManager.UpdateAccountInfo(auth);
            var result = _mapper.Map<AuthorizationResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return ex.Message switch
            {
                "Cannot find user with such Authorization Id" => Ok("ПОЛЬЗОВАТЕЛЬ НЕ НАЙДЕН"),
                "Login already exist" => Ok("ЛОГИН ЗАНЯТ"),
                _ => Ok("ЧТОТО ПОШЛО НЕ ТАК")
            };
        }
    }



    [HttpPost("create-an-account-by-admin")]
    public IActionResult CreateAnAccountByAdmin([FromBody] AuthorizationAddByAdminRequest authorizationRequest)
    {
        try
        {
            var auth = _mapper.Map<Authorization>(authorizationRequest);
            var callback = _userManager.CreateAnAccount(auth);
            var result = _mapper.Map<AuthorizationResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok(ex.Message == "Login already exist" ? "ЛОГИН ЗАНЯТ" : "ЧТОТО ПОШЛО НЕ ТАК");
        }
    }
    [HttpPut("update-an-account-by-admin")]
    public IActionResult UpdateAuthorizationByAdmin([FromQuery] AuthorizationUpdateByAdminRequest authorizationRequest)
    {
        try
        {
            var auth = _mapper.Map<Authorization>(authorizationRequest);
            var callback = _userManager.UpdateAccountInfo(auth);
            var result = _mapper.Map<AuthorizationResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Ok("ЧТОТО ПОШЛО НЕ ТАК");
        }
    }


    [HttpPost("add-user-info")]
    public async Task<IActionResult> AddUserInfo([FromBody] UserAddRequest userRequest)
    {
        var user = _mapper.Map<User>(userRequest);
        var callback = await _userManager.AddUserInfo(user);
        var result = _mapper.Map<UserResponse>(callback);
        return Ok(result);
    }
    [HttpPost("update-user-info")]
    public IActionResult UpdateUserInfo([FromBody] UserUpdateRequest userRequest)
    {
        try
        {
            var user = _mapper.Map<User>(userRequest);
            var callback = _userManager.UpdateUserInfo(user);
            var result = _mapper.Map<UserResponse>(callback);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return ex.Message switch
            {
                "Cannot find user with such Id" => Ok("ПОЛЬЗОВАТЕЛЬ НЕ НАЙДЕН"),
                _ => Ok("ЧТОТО ПОШЛО НЕ ТАК")
            };
        }
    }

    [HttpGet("get-user-{id}")]
    public IActionResult GetUserById([FromRoute] int id)
    {
        try
        {
            var user = _userManager.GetUserById(id);
            var result = _mapper.Map<UserResponse>(user);
            return Ok(result);
        }
        catch (ObjectNotExistException ex)
        {
            return Ok($"{ex.Message}");
        }
        catch (Exception ex)
        {
            return Ok("ЧТОТО ПОШЛО НЕ ТАК");
        }
    }
}