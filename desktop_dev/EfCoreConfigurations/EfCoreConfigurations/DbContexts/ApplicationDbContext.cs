using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCoreConfigurations.Entities;

namespace EfCoreConfigurations.DbContexts;
public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(userConfiguration =>
        {
            userConfiguration.HasKey(u => u.Id);
            userConfiguration.Property(u => u.Username).HasMaxLength(32);
            userConfiguration.HasIndex(u => u.Username).IsUnique();
        });
        modelBuilder.Entity<Role>(roleConfiguration =>
        {
            roleConfiguration.HasKey(r => r.Id);
            roleConfiguration.Property(r => r.Description).HasMaxLength(512);
            roleConfiguration.HasIndex(r => r.Title).IsUnique();
            roleConfiguration.Property(r => r.Title).HasMaxLength(64);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost; user=root; password=1212; database=ECore;", new MySqlServerVersion(new Version(8, 0, 40)));
    }
}