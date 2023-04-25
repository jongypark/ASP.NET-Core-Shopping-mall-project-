using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> context) : base(context)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}