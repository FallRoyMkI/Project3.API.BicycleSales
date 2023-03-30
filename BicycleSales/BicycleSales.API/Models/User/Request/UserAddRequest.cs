
namespace BicycleSales.API.Models.User.Request
{
    public class UserAddRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsMale { get; set; }
        public int AuthorizationId { get; set; }
        public int ShopId { get; set; }
    }
}
