using libreriaa_JAMB.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Publisher = libreriaa_JAMB.Data.Models.Publisher;

namespace libreriaa_JAMB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
           .HasOne(b => b.Books)
            .WithMany(ba => ba.Book_Authors)
            .HasForeignKey(bi => bi.BookId);  

             modelBuilder.Entity<Book_Author>()
            .HasOne(b => b.Author)
           .WithMany(ba => ba.Book_Authors)
           .HasForeignKey(bi => bi.AuthorId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

    }
}
