using libreriaa_JAMB.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace libreriaa_JAMB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}
