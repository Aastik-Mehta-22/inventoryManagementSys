using Microsoft.EntityFrameworkCore;

namespace InventoryApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // This creates the 'Items' table in SQLite using the InventoryItem schema 
        public DbSet<InventoryItem> Items { get; set; }
    }
}