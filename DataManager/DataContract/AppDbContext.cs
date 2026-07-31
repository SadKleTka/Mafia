using DomainModel.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataManager.DataContract;

/// <summary>
/// Класс для подключения к базе данных и создания Entity сущностей
/// </summary>
public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Lobby> Lobbies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Username)
            .IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Email)
            .IsUnique();
        
        modelBuilder.Entity<Lobby>()
            .HasIndex(e => e.Name)
            .IsUnique();
    }
}