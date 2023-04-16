using Microsoft.EntityFrameworkCore;
using BicycleSales.DAL.Models;

namespace BicycleSales.DAL.Contexts
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductDto> Product { get; set; }
        public DbSet<TagDto> Tag { get; set; }
        public DbSet<ProductTagDto> ProductTag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=DESKTOP-MH87Q5L\SQLEXPRESS;
                                                Initial Catalog = VELIKI; TrustServerCertificate=True;Integrated Security=SSPI", 
                             builder => builder.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTagDto>()
                .HasKey(t => new { t.ProductId, t.TagId });

            modelBuilder.Entity<ProductTagDto>()
                .HasOne(sc => sc.Product)
                .WithMany(s => s.ProductTags)
                .HasForeignKey(sc => sc.ProductId);

            modelBuilder.Entity<ProductTagDto>()
                .HasOne(sc => sc.Tag)
                .WithMany(c => c.ProductTags)
                .HasForeignKey(sc => sc.TagId);
        }
    }
}
