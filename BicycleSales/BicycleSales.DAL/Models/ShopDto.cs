using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleSales.DAL.Models
{
    public class ShopDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public bool IsDeleted { get; set; }
        public override bool Equals(object? obj)
        {
            return obj is ShopDto shop &&
                   Id == shop.Id &&
                   Name == shop.Name &&
                   Location == shop.Location;
        }
    }

    public class ShopProductDto
    {
        [Key]
        public int Id { get; set; }
        public int ProductCount { get; set; }

        public int ShopId { get; set; }

        [ForeignKey(nameof(ShopId))]
        public virtual ShopDto Shop { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductDto Product { get; set; }
    }
}
