using BicycleSales.API.Models.AuthorizationProduct.Request;
using BicycleSales.API.Models.AuthorizationProduct.Response;
using BicycleSales.API.Models.User.Request;
using BicycleSales.API.Models.User.Response;
using BicycleSales.BLL.Models;

namespace BicycleSales.API.Interfaces
{
    public interface IMapperAPI
    {
        public AuthorizationResponse MapAuthorizationToAuthorizationResponse(Authorization authBLL);
        public Authorization MapAuthorizationAddRequestToAuthorization(AuthorizationAddRequest authAddRequest);

        public Authorization MapAuthorizationAddRequestByAdminToAuthorization(AuthorizationAddByAdminRequest authAddRequest);

        public Authorization MapAuthorizationUpdateRequestToAuthorization(AuthorizationUpdateRequest authUpdateRequest);

        public Authorization MapAuthorizationUpdateByAdminRequestByAdminToAuthorization(AuthorizationUpdateByAdminRequest authAddRequest);

        public UserResponse MapUserToUserResponse(User userAddRequest);
        public User MapUserAddRequestToUser(UserAddRequest userAddRequest);
    }
}
