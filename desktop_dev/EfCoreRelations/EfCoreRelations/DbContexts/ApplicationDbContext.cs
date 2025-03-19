using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCoreRelations.Entities;

namespace EfCoreRelations.DbContexts;
public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<UserRoles> UserRoles { get; set; } = null!;
    public DbSet<RolePermissions> RolePermissions { get; set; } = null!;
    public DbSet<Note> Notes { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(userConfiguration =>
        {
            userConfiguration.HasKey(u => u.Id);
            userConfiguration.Property(u => u.Login).HasMaxLength(32);
            userConfiguration.HasIndex(u => u.Login).IsUnique();
            userConfiguration.HasMany(u => u.Roles).WithMany(u => u.Users).UsingEntity<UserRoles>(
                l => l.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId),
                r => r.HasOne(ur => ur.User).WithMany().HasForeignKey(ur => ur.UserId));
            userConfiguration.HasMany(u => u.Notes).WithOne(n => n.User);
        });

        modelBuilder.Entity<Role>(roleConfiguration =>
        {
            roleConfiguration.HasKey(r => r.Id);
            roleConfiguration.HasIndex(r => r.Title).IsUnique();
            roleConfiguration.Property(r => r.Title).HasMaxLength(32);
            roleConfiguration.Property(r => r.Description).HasMaxLength(512);
            roleConfiguration.HasMany(u => u.Users).WithMany(u => u.Roles).UsingEntity<UserRoles>(
                l => l.HasOne(ur => ur.User).WithMany().HasForeignKey(ur => ur.UserId),
                r => r.HasOne(ur => ur.Role).WithMany().HasForeignKey(ur => ur.RoleId));
            roleConfiguration.HasMany(p => p.Permissions).WithMany(p => p.Roles).UsingEntity<RolePermissions>(
                k => k.HasOne(rp => rp.Permission).WithMany().HasForeignKey(rp => rp.Permissionid),
                a => a.HasOne(rp => rp.Role).WithMany().HasForeignKey(rp => rp.Roleid)
                );
        });
        modelBuilder.Entity<Permission>(permissionConfiguration => {
            permissionConfiguration.HasKey(p => p.Id);
            permissionConfiguration.HasIndex(p => p.Title).IsUnique();
            permissionConfiguration.Property(p => p.Title).HasMaxLength(32);
            permissionConfiguration.Property(p => p.Description).HasMaxLength(512);
            permissionConfiguration.HasMany(p => p.Roles).WithMany(p => p.Permissions).UsingEntity<RolePermissions>(
                k => k.HasOne(rp => rp.Role).WithMany().HasForeignKey(rp => rp.Roleid),
                a => a.HasOne(rp => rp.Permission).WithMany().HasForeignKey(rp => rp.Permissionid)
                );
        });
        modelBuilder.Entity<Note>(noteConfiguration => {
            noteConfiguration.HasKey(n => n.Id);
            noteConfiguration.HasIndex(n => n.Title).IsUnique();
            noteConfiguration.Property(n => n.Title).HasMaxLength(32);
            noteConfiguration.Property(n => n.Description).HasMaxLength(512);
            noteConfiguration.HasOne(n => n.User).WithMany(n => n.Notes).HasForeignKey(n => n.Userid);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost; user=root; password=1212; database=EfCore", new MySqlServerVersion(new Version(8, 0, 40)));
    }
}
