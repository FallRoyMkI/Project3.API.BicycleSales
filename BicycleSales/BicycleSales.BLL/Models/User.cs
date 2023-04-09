using BicycleSales.BLL.Constant;

namespace BicycleSales.BLL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsMale { get; set; }
        public UserStatus UserType { get; set; }
        public Authorization Authorization { get; set; }
        public Shop Shop { get; set; }
    }

    public class Authorization
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
