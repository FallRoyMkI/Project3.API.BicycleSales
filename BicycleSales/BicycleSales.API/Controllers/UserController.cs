using BicycleSales.API.Models.AuthorizationProduct.Request;
using BicycleSales.API.Models.AuthorizationProduct.Response;
using BicycleSales.API.Models.User.Request;
using BicycleSales.API.Models.User.Response;
using BicycleSales.BLL;
using Microsoft.AspNetCore.Mvc;

namespace BicycleSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MapperAPI _mapper = new();

        [HttpGet(Name = "CreateNewUser")]
        public AuthorizationResponse CreateNewAccount(string login, string password)
        {
            var authRequest = new AuthorizationAddRequest()
            {
                Login = login,
                Password = password
            };

            var auth = _mapper.MapAuthorizationAddRequestToAuthorization(authRequest);
            var callback = new UserManager().CreateAnAccount(auth);
            var result = _mapper.MapAuthorizationToAuthorizationResponse(callback);
            return result;
        }

        [HttpGet("/AddUserInfo",Name = "AddUserInfo")]
        public UserResponse AddUserInfo(string name, string email, string phone, bool isMale, int authId, int shopId)
        {
            var userAddRequest = new UserAddRequest()
            {
                Name = name,
                Email = email,
                Phone = phone,
                IsMale = isMale,
                AuthorizationId = authId,
                ShopId = shopId
            };

            var user = _mapper.MapUserAddRequestToUser(userAddRequest);
            var callback = new UserManager().AddUserInfo(user);
            var result = _mapper.MapUserToUserResponse(callback);
            return result;
        }
    }
}
