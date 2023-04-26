using Microsoft.EntityFrameworkCore;
using BicycleSales.DAL.Models;

namespace BicycleSales.DAL.Contexts;

public class Context : DbContext
{
    public DbSet<AuthorizationDto> Authorizations { get; set; }
    public DbSet<UserDto> Users { get; set; }
    public DbSet<AcceptanceDto> Acceptances { get; set; }
    public DbSet<AcceptanceProductDto> AcceptanceProducts { get; set; }
    public DbSet<OrderDto> Orders { get; set; }
    public DbSet<OrderProductDto> OrdersProducts { get; set; }
    public DbSet<ProductDto> Products { get; set; }
    public DbSet<TagDto> Tags { get; set; }
    public DbSet<ProductTagDto> ProductTags { get; set; }
    public DbSet<ShipmentDto> Shipments { get; set; }
    public DbSet<ShipmentProductDto> ShipmentProducts { get; set; }
    public DbSet<ShopDto> Shops { get; set; }
    public DbSet<ShopProductDto> ShopProducts { get; set; }
    public DbSet<ShipmentAcceptanceDto> ShipmentAcceptances { get; set; }
    public DbSet<FactoryDto> Factory { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Data Source=DESKTOP-62LIE27;
                                                Initial Catalog = VELIKI; TrustServerCertificate=True;Integrated Security=SSPI",
                             builder => builder.EnableRetryOnFailure());
    }
}