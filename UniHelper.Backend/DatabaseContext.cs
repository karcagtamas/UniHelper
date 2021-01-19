using Microsoft.EntityFrameworkCore;
using UniHelper.Backend.Models;

namespace UniHelper.Backend
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<SubjectNote> SubjectNotes { get; set; }
        public DbSet<SubjectTask> SubjectTasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<PeriodNote> PeriodNotes { get; set; }
        public DbSet<PeriodTask> PeriodTasks { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<GlobalNote> GlobalNotes { get; set; }
        public DbSet<GlobalTask> GlobalTasks { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.Courses)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();

            builder.Entity<SubjectNote>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.Notes)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();
            
            builder.Entity<SubjectTask>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.Tasks)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();
            
            builder.Entity<Subject>()
                .HasOne(x => x.Period)
                .WithMany(x => x.Subjects)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();
            
            builder.Entity<PeriodNote>()
                .HasOne(x => x.Period)
                .WithMany(x => x.Notes)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();
            
            builder.Entity<PeriodTask>()
                .HasOne(x => x.Period)
                .WithMany(x => x.Tasks)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired();
        }
    }
}