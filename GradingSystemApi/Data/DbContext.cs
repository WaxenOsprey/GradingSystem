using Microsoft.EntityFrameworkCore;
using GradingSystem.models;


namespace GradingSystem.data
{
    public class GradingSystemContext : DbContext
    {
        public DbSet<Cohort> Cohorts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public GradingSystemContext(DbContextOptions<GradingSystemContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=gradingSystem.db")
            .LogTo(Console.WriteLine, LogLevel.Information);

        }
    }
}
