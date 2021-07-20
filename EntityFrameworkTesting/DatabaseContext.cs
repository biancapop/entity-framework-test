using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTesting
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=todoapp.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
               .HasOne<Category>(t => t.Category)
               .WithMany(c => c.Tasks);

            modelBuilder.Entity<Category>()
               .HasMany<Task>(c => c.Tasks)
               .WithOne(t => t.Category);
        }
    }
}
