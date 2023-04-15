using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models
{
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int Cost { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductTagDto> ProductTags { get;} = new List<ProductTagDto>();
    }

    public class ProductTagDto
    {
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

        public int TagId { get; set; }
        public TagDto Tag { get; set; }
    }

    public class TagDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public List<ProductTagDto> ProductTags { get; set; } = new List<ProductTagDto>();
    }
}
