using Microsoft.EntityFrameworkCore;
using BicycleSales.DAL.Models;

namespace BicycleSales.DAL.Contexts;

public class AcceptanceContext : DbContext
{
    public DbSet<AcceptanceDto> Acceptances { get; set; }
    public DbSet<AcceptanceProductDto> AcceptanceProduct { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // builder.UseSqlServer("Data Source=DESKTOP-62LIE27;Initial Catalog = VELIKI; " +
        //                      "TrustServerCertificate=True;Integrated Security=SSPI", builder => builder.EnableRetryOnFailure());

        builder.UseInMemoryDatabase("forTest");
    }
}