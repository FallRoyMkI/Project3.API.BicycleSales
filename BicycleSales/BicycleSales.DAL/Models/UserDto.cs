
namespace BicycleSales.DAL.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsMale { get; set; }
        public UserTypeDto UserType { get; set; }
        public AuthorizationDto Authorization { get; set; }
        public ShopDto Shop { get; set; }
    }
}
