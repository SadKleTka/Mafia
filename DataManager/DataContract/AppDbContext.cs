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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}