using Microsoft.EntityFrameworkCore;

namespace Blue_it.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Answer>? Answers { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=./Data/BlueitDb");
        
    }
}
