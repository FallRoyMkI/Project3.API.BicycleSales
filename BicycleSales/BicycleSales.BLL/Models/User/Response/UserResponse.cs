using BicycleSales.BLL.Models.Authorization.Response;
using BicycleSales.BLL.Models.Shop.Response;
using BicycleSales.BLL.Models.UserType.Response;


namespace BicycleSales.BLL.Models.User.Response
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
