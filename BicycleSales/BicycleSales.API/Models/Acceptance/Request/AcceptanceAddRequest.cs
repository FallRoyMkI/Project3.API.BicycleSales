
namespace BicycleSales.API.Models.Acceptance.Request
{
    public class AcceptanceAddRequest
    {
        public DateTime PlanedTime { get; set; }
        public int UserIdWhichFormed { get; set; }
        public int ShopId { get; set; }
    }
}
