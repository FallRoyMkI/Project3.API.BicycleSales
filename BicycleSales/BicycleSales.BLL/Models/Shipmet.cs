namespace BicycleSales.BLL.Models
{
    public class Shipmet
    {
        public int Id { get; set; }
        public DateTime PlanedTime { get; set; }
        public DateTime FactTime { get; set; }
        public User FormedBy { get; set; }
        public User SignedBy { get; set; }
        public Shop Shop { get; set; }
    }
}
