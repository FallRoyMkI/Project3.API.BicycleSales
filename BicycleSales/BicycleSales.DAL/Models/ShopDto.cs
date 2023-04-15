using System.ComponentModel.DataAnnotations;

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
        public int ProductCount { get; set; }
        public ShopDto ShopId { get; set; }
        public ProductDto Product { get; set; }
    }
}
