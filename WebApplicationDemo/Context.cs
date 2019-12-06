using Microsoft.EntityFrameworkCore;

namespace WebApplicationDemo
{
    public class Context: DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=demo.db");
        }
    }
}