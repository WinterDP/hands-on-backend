using EventsLogger.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsLogger.Data;

public class UserContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public UserContext(DbContextOptions<UserContext> options) : base(options)
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

}