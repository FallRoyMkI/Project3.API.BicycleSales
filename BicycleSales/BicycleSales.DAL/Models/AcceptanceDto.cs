namespace BicycleSales.BLL.Models
{
    public class AcceptanceDto
    {
        public int Id { get; set; }
        public DateTime PlanedTime { get; set; }
        public DateTime FactTime { get; set; }
        public UserDto FormedBy { get; set; }
        public UserDto SignedBy { get; set; }
        public ShopDto Shop { get; set; }
    }
}
