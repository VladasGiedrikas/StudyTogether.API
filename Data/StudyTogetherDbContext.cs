using Microsoft.EntityFrameworkCore;
using StudyTogether.API.Models;

namespace StudyTogether.API.Data
{
    public class StudyTogetherDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Grade> Grades { get; set; }


        public StudyTogetherDbContext(DbContextOptions<StudyTogetherDbContext> options)
        : base(options)
        {          
        }
        // galime perrasyti virtual metodus is paveldimos klases
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
        }
      
    }
}
