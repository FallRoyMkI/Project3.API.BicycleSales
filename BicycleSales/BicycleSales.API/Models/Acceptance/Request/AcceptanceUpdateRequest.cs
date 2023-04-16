
namespace BicycleSales.API.Models.Acceptance.Request
{
    public class AcceptanceUpdateRequest
    {
        public int Id { get; set; }
        public DateTime FactTime { get; set; }
        public int UserIdWhichSigned { get; set; }
    }
}
