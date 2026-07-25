using E_Commerce.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Data
{
    internal class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
    {
        DbSet<Product> Products { get; set; } = default!;
        DbSet<ProductBrand> ProductBrands { get; set; } = default!;
        DbSet<ProductType> ProductTypes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);

        }
    }
}
