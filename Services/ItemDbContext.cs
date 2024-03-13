using Microsoft.EntityFrameworkCore;

namespace ItemAPI;

public class ItemDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ItemDB.db");
        //optionsBuilder.UseInMemoryDatabase("Item");
    } 
   
}

