using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; } //Book aslında Db'deki Books objesinin bir replikası diyebiliriz!
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }



    }
}