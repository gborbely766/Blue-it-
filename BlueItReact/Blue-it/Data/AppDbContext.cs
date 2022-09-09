using Microsoft.EntityFrameworkCore;

namespace Blue_it.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=./Data/BlueitDb.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Question questionsToAdd = new()
            {
                Id = 1,
                Title = "This is Question nr.1",
                Message = "This is message for Question Nr.1",
                Image = "This will be a path to an image for Question Nr.1"
            };
                 
            modelBuilder.Entity<Question>().HasData(questionsToAdd);
        }
    }
}
