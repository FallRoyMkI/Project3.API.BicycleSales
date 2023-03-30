namespace BicycleSales.DAL.Models
{
    public class ShipmetDto
    {
        public int Id { get; set; }
        public DateTime PlanedTime { get; set; }
        public DateTime FactTime { get; set; }
        public UserDto FormedBy { get; set; }
        public UserDto SignedBy { get; set; }
        public ShopDto Shop { get; set; }
    }
}
