using BicycleSales.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleSales.DAL.Contexts
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductDto> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=DESKTOP-MH87Q5L\SQLEXPRESS;Initial Catalog = VELIKI; TrustServerCertificate=True;Integrated Security=SSPI", builder => builder.EnableRetryOnFailure());
        }
    }
}
