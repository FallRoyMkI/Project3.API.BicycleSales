
namespace BicycleSales.BLL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
    }

    public class ProductTag
    {
        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
