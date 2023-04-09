using BicycleSales.API.Models.AuthorizationProduct.Request;
using BicycleSales.API.Models.AuthorizationProduct.Response;
using BicycleSales.API.Models.Shop.Response;
using BicycleSales.API.Models.UserType.Response;

namespace BicycleSales.API.Models.User.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsMale { get; set; }
        public UserTypeResponse UserType { get; set; }
        public AuthorizationResponse Authorization { get; set; }
        public ShopResponse Shop { get; set; }
    }
}
