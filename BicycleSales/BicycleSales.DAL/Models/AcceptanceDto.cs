using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleSales.DAL.Models
{
    public class AcceptanceDto
    {
        [Key]
        public int Id { get; set; }
        public DateTime PlanedTime { get; set; }
        public DateTime FactTime { get; set; }
        public int FormedById { get; set; }

        [ForeignKey(nameof(FormedById))]
        public virtual UserDto FormedBy { get; set; }

        public int SignedById { get; set; }

        [ForeignKey(nameof(SignedById))]
        public virtual UserDto SignedBy { get; set; }

        public int ShopId { get; set; }

        [ForeignKey(nameof(ShopId))]
        public virtual ShopDto Shop { get; set; }
    }

    public class AcceptanceProductDto
    {
        [Key]
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int FactProductCount { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductDto Product { get; set; }

        public int AcceptanceId { get; set; }

        [ForeignKey(nameof(AcceptanceId))]
        public virtual AcceptanceDto Acceptance { get; set; }
    }
}
