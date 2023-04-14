using AutoMapper;
using BicycleSales.API.Models.AuthorizationProduct.Request;
using BicycleSales.API.Models.AuthorizationProduct.Response;
using BicycleSales.API.Models.Product.Request;
using BicycleSales.API.Models.Product.Response;
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

                cfg.CreateMap<ProductAddRequest, Product>();
                cfg.CreateMap<Product, ProductResponse>();
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
    public Product MapProductAddRequestToProduct(ProductAddRequest productAddRequest)
    {
        return _cfg.CreateMapper().Map<Product>(productAddRequest);
    }
    public ProductResponse MapProductToProductResponse(Product productBll)
    {
        return _cfg.CreateMapper().Map<ProductResponse>(productBll);
    }
    public IEnumerable<ProductResponse> MapListProductToListProductResponse(IEnumerable<Product> listProducts)
    {
        return _cfg.CreateMapper().Map<IEnumerable<ProductResponse>>(listProducts);
    }

}