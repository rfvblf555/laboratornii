using ElectroinicShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElectroinicShop.DatabaseContext;


public class ApplicationDbContext : DbContext
{
    public DbSet<ProductEntity> Products { get; set; } = null!;

    public DbSet<UserEntity> Users { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>(productsConfiguration =>
        {
            productsConfiguration.HasKey(p => p.Id);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=1212;database=EShopDb", new MySqlServerVersion(new Version(0, 0, 11)));
    }
}
