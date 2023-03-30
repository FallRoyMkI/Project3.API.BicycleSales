﻿
namespace BicycleSales.API.Models.User.Request
{
    public class UserUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsMale { get; set; }
        public int UserTypeId { get; set; }
        public int ShopId { get; set; }
    }
}
