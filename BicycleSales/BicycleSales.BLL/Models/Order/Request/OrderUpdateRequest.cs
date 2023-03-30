
namespace BicycleSales.BLL.Models.Order.Request
{
    public class OrderUpdateRequest
    {
        public int Id { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public int OrderStatusId { get; set; }
    }
}
