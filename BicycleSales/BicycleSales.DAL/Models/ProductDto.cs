using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleSales.DAL.Models
{
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Cost { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class ProductTagDto
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductDto Product { get; set; }

        public int TagId { get; set; }

        [ForeignKey(nameof(TagId))]
        public virtual TagDto Tag { get; set; }
    }

    public class TagDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

    }
}
