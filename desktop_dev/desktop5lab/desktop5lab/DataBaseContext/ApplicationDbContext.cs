using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using desktop5lab.Entities;

namespace desktop5lab.DataBaseContext;
public class ApplicationDbContext : DbContext
{
    public DbSet<PersonEntity> People { get; set; }
    public DbSet<NoteEntity> Notes { get; set; }

    public ApplicationDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonEntity>(peopleTableBuilder =>
        {
            peopleTableBuilder.HasKey(p => p.Id);


        });

        modelBuilder.Entity<NoteEntity>(noteTableBuilder =>
        {
            noteTableBuilder.HasKey(p => p.Id);

            noteTableBuilder
                .HasOne<PersonEntity>(r => r.Person)
                .WithMany(p => p.Notes)
                .HasForeignKey(p => p.UserId);

        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=localhost;user=root;password=1212;database=laba5",
            new MySqlServerVersion(new Version(8, 0, 38)));
    }
}
