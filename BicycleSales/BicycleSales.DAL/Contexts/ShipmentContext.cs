using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleSales.DAL.Contexts;

public class ShipmentContext : DbContext
{
    public DbSet<ShipmentDto> Shipments { get; set; }
    public DbSet<ShipmentProductDto> ShipmentProduct { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // builder.UseSqlServer("Data Source=DESKTOP-62LIE27;Initial Catalog = VELIKI; " +
        //                      "TrustServerCertificate=True;Integrated Security=SSPI", builder => builder.EnableRetryOnFailure());

        builder.UseInMemoryDatabase("forTest");
    }
}