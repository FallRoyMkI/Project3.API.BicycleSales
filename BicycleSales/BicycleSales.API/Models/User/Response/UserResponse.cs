using BicycleSales.API.Models.AuthorizationProduct.Response;
using BicycleSales.API.Models.Shop.Response;
using BicycleSales.API.Models.UserType.Response;

namespace BicycleSales.API.Models.User.Response
{
    public class UserAddRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsMale { get; set; }
        public UserTypeResponse UserType { get; set; }
        public AuthorizationAddRequest Authorization { get; set; }
        public ShopAddRequest Shop { get; set; }
    }
}
