
namespace BicycleSales.Constants.CustomExceptions.Shop
{
    public class ShopException : Exception  
    {
        public ShopException() { }
        public ShopException(string message) : base(message) { }
    }
}
