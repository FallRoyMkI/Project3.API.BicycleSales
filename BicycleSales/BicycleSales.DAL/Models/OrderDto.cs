using BicycleSales.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleSales.DAL.Models
{
    public class OrderDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCompilation { get; set; }
        public DateTime DateOfCompletion { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserDto User { get; set; }

        public int ShopId { get; set; }

        [ForeignKey(nameof(ShopId))]
        public ShopDto Shop { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.OrderCreated;
    }

    public class OrderProductDto
    {
        [Key]
        public int Id { get; set; } 
        public int ProductCount { get; set; }
        public int ReadyProductCount { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual OrderDto Order { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductDto Product { get; set; }
    }
}
