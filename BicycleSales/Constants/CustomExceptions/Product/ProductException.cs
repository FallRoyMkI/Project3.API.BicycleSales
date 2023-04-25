
namespace BicycleSales.Constants.CustomExceptions.Product
{
    public class ProductException : Exception
    {
        public ProductException() { }
        public ProductException(string message) : base(message) { }
    }
}
