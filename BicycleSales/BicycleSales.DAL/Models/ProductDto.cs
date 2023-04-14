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
    }

    public class ProductTagDto
    {
        public ProductDto Product { get; set; }
        public TagDto Tag { get; set; }
    }

    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
