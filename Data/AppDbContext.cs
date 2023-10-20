using EventsLogger.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventsLogger.Data;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid(),
                Name = "admin",
                Password = "admin",
                Email = "admin@admin.com",
                Role = UserRoles.admin,
                PhotoPath = "",
            });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

    }

}