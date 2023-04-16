using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleSales.DAL.Contexts;
public class ShopContext : DbContext
{
    public DbSet<ShopDto> Shop { get; set; }

    public DbSet<ShopProductDto> ShopProduct { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        //builder.UseSqlServer(@"Data Source=DESKTOP-MH87Q5L\SQLEXPRESS;
        //                                    Initial Catalog = VELIKI; TrustServerCertificate=True;Integrated Security=SSPI", 
        //                    builder => builder.EnableRetryOnFailure());
        builder.UseInMemoryDatabase("FOR TEST");
    }
}
