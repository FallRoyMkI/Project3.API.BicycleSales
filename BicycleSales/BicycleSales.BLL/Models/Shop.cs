namespace BicycleSales.BLL.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class ShopProduct
    {
        public int ProductCount { get; set; }
        public Shop ShopId { get; set; }
        public Product Product { get; set; }
    }
}
