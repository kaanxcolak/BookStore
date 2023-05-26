using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class BookStoreDbContext:DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options): base(options)
        {

        }

        public DbSet<Book> Books{get;set;} //Book aslında Db'deki Books objesinin bir replikası diyebiliriz!
         
        
    }
}