using BicycleSales.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleSales.DAL.Models
{
    public class ShipmentAcceptanceDto
    {
        [Key]
        public int Id { get; set; } 
        public int ShipmentId { get; set; }

        [ForeignKey(nameof(ShipmentId))]
        public ShipmentDto Shipment { get; set; }

        public int AcceptanceId { get; set; }

        [ForeignKey(nameof(AcceptanceId))]
        public AcceptanceDto Acceptance { get; set; }

        public ShipmentAcceptanceStatus Status { get; set; } = ShipmentAcceptanceStatus.ShipmentCreated;

        public int FactoryId { get; set; }

        [ForeignKey(nameof(FactoryId))]
        public FactoryDto Factory { get; set; }
    }

    public class FactoryDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
