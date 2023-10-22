using EventsLogger.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsLogger.Data
{
    public class EntryContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public EntryContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<Entry> Users { get; set; }
    }
}