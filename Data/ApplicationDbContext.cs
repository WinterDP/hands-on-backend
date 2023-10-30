using EventsLogger.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsLogger.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<RelationshipProjectUsers> RelationshipProjectUsers { get; set; }
        public DbSet<RelationshipUserEntryProject> RelationshipUserEntryProject { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RelationshipUserEntryProject>().HasKey(
                r => new { r.EntryId , r.UserId, r.ProjectId}
                );
            modelBuilder.Entity<RelationshipProjectUsers>().HasKey(
                r => new { r.UserId, r.ProjectId }
                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "admin",
                    Email = "admin@admin.com",
                    Password = "admin",
                    Role = "admin",
                    PhotoPath = "",
                }
                );
        }
    }
}
