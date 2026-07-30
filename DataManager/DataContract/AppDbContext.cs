using DomainModel.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataManager.DataContract;

/// <summary>
/// Класс для подключения к базе данных и создания Entity сущностей
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}
    
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}