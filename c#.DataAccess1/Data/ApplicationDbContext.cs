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
        public DbSet<MyProperty> MyProperty { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<MyProperty>().HasData(
                new MyProperty { Id = 1, Name = "Sports", DisplayOrder = 1 },
                new MyProperty { Id = 2, Name = "School", DisplayOrder = 2 },
                new MyProperty { Id = 3, Name = "Games", DisplayOrder = 3 }
                );
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
