#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Models;

public class MyContext : DbContext
{  
    // This line will always be here. It is what constructs our context upon initialization  
    public MyContext(DbContextOptions options) : base(options) { }    
    
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Wedding> Weddings { get; set; }
    public DbSet<User> Users { get; set; }
}
