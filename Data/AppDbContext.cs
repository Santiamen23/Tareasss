using Microsoft.EntityFrameworkCore;
using BooksTW.Models;

namespace BooksTW.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Book> books => Set<Book>();
        public DbSet<User> users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>();
            modelBuilder.Entity<User>();
        }
    }
}
