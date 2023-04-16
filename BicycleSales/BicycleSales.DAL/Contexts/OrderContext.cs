using Microsoft.EntityFrameworkCore;
using BicycleSales.DAL.Models;

namespace BicycleSales.DAL.Contexts;

public class OrderContext : DbContext
{
    public DbSet<OrderDto> Orders { get; set; }
    public DbSet<OrderProductDto> OrdersProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
         //builder.UseSqlServer("Data Source=DESKTOP-62LIE27;Initial Catalog = VELIKI;" +
         //                     "TrustServerCertificate=True;Integrated Security=SSPI", 
         //    builder => builder.EnableRetryOnFailure());
        builder.UseInMemoryDatabase("ForTest");
    }
}