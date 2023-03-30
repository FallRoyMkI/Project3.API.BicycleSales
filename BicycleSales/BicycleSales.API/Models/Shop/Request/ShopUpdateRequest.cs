namespace BicycleSales.API.Models.Shop.Request
{
    public class ShopUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
