
namespace BicycleSales.DAL.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
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
