using Microsoft.EntityFrameworkCore;

namespace SentwoAPI.Models
{
    public class EntryContext : DbContext
    {
        public EntryContext(DbContextOptions<EntryContext> options)
            : base(options)
        {
        }

        public DbSet<Entry> EntryContexts { get; set; }
    }
}
