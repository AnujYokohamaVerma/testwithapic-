using Microsoft.EntityFrameworkCore;
using testwithapic_.Models;

namespace testwithapic_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) 
        {

        }
        public DbSet<Category> Categoryies { get; set; }
        public DbSet<MyProperty> MyProperty {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                )
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=YourDatabaseName;Trusted_Connection=True;");
            }

        }
    }
}
