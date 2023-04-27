using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleSales.Constants.CustomExceptions.ShopProduct
{
    public class ShopProductException : Exception
    {
        public ShopProductException() { }
        public ShopProductException(string message) : base(message) { }
    }
}
