namespace BicycleSales.BLL.Models
{
    public class Acceptance
    {
        public int Id { get; set; }
        public DateTime PlanedTime { get; set; }
        public DateTime FactTime { get; set; }
        public User FormedBy { get; set; }
        public User SignedBy { get; set; }
        public Shop Shop { get; set; }
    }

    public class AcceptanceProduct
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int FactProductCount { get; set; }
        public Product Product { get; set; }
        public Acceptance Acceptance { get; set; }
    }
}
