using Book_Store.Data;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Datalayer
{
    public class Application : DbContext
    {
        public Application(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BookEntity> BookCollection { get; set; }
        public DbSet<Category> BookCategorys { get; set; }
        public DbSet<LoginAndRegDb> Info { get; set; }
    }
}
