namespace BicycleSales.API.Models.AuthorizationProduct.Request
{
    public class AuthorizationUpdateRequest
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
    }
}
