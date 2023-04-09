using AutoMapper;
using BicycleSales.API.Models.AuthorizationProduct.Request;
using BicycleSales.API.Models.AuthorizationProduct.Response;
using BicycleSales.API.Models.User.Request;
using BicycleSales.API.Models.User.Response;
using BicycleSales.BLL.Models;
using BicycleSales.DAL.Models;

namespace BicycleSales.API;

public class MapperAPI
{
    private readonly MapperConfiguration _cfg;
    public MapperAPI()
    {
        _cfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Authorization, AuthorizationResponse>();
                cfg.CreateMap<AuthorizationAddRequest, Authorization>();

                cfg.CreateMap<User, UserResponse>();
                cfg.CreateMap<UserAddRequest, User>();
            });
    }

    public AuthorizationResponse MapAuthorizationToAuthorizationResponse(Authorization authBLL)
    {
        return _cfg.CreateMapper().Map<AuthorizationResponse>(authBLL);
    }
    public Authorization MapAuthorizationAddRequestToAuthorization(AuthorizationAddRequest authAddRequest)
    {
        return _cfg.CreateMapper().Map<Authorization>(authAddRequest);
    }

    public UserResponse MapUserToUserResponse(User userAddRequest)
    {
        return _cfg.CreateMapper().Map<UserResponse>(userAddRequest);
    }
    public User MapUserAddRequestToUser(UserAddRequest userAddRequest)
    {
        return _cfg.CreateMapper().Map<User>(userAddRequest);
    }

    
}