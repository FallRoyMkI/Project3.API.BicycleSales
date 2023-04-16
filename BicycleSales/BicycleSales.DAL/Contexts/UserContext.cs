using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleSales.DAL.Contexts;

public class UserContext : DbContext
{
    public DbSet<AuthorizationDto> Authorizations { get; set; }
    public DbSet<UserDto> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
<<<<<<< HEAD:BicycleSales/BicycleSales.DAL/UserContext.cs
    {
    // builder.UseSqlServer("Data Source=DESKTOP-62LIE27;Initial Catalog = VELIKI; " +
    //                      "TrustServerCertificate=True;Integrated Security=SSPI", builder => builder.EnableRetryOnFailure());

     builder.UseInMemoryDatabase("forTest");
=======
    {
        builder.UseSqlServer(@"Data Source=DESKTOP-MH87Q5L\SQLEXPRESS;Initial Catalog = VELIKI; TrustServerCertificate=True;Integrated Security=SSPI", builder => builder.EnableRetryOnFailure());
        //builder.UseInMemoryDatabase("ForTest");
>>>>>>> main:BicycleSales/BicycleSales.DAL/Contexts/UserContext.cs
    }
}