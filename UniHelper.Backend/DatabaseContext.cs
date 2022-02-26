using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend;

/// <summary>
/// Database Context
/// </summary>
public class DatabaseContext : DbContext
{
    /// <summary>
    /// Course Table
    /// </summary>
    public DbSet<Course> Courses { get; set; }

    /// <summary>
    /// Subject Task Table
    /// </summary>
    public DbSet<SubjectTask> SubjectTasks { get; set; }

    /// <summary>
    /// Subject Table
    /// </summary>
    public DbSet<Subject> Subjects { get; set; }

    /// <summary>
    /// Period Task Table
    /// </summary>
    public DbSet<PeriodTask> PeriodTasks { get; set; }

    /// <summary>
    /// Period Table
    /// </summary>
    public DbSet<Period> Periods { get; set; }

    /// <summary>
    /// Task Table
    /// </summary>
    public DbSet<GlobalTask> GlobalTasks { get; set; }

    /// <summary>
    /// Lesson Hour Table
    /// </summary>
    public DbSet<LessonHour> LessonHours { get; set; }

    /// <summary>
    /// User Table
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Init Database Context
    /// </summary>
    /// <param name="options">Database Context options</param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Course>()
            .HasOne(x => x.Subject)
            .WithMany(x => x.Courses)
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

        builder.Entity<PeriodTask>()
            .HasOne(x => x.Period)
            .WithMany(x => x.Tasks)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.Entity<GlobalTask>()
            .HasOne(x => x.User)
            .WithMany(x => x.Tasks)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.Entity<Period>()
            .HasOne(x => x.User)
            .WithMany(x => x.Periods)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.Entity<LessonHour>()
            .HasData(new List<LessonHour>
            {
                new()
                {
                    Id = 1,
                    Start = new TimeSpan(7, 40, 0),
                    End = new TimeSpan(8, 25, 0),
                    Number = 0
                },
                new()
                {
                    Id = 2,
                    Start = new TimeSpan(8, 30, 0),
                    End = new TimeSpan(9, 15, 0),
                    Number = 1
                },
                new()
                {
                    Id = 3,
                    Start = new TimeSpan(9, 25, 0),
                    End = new TimeSpan(10, 10, 0),
                    Number = 2
                },
                new()
                {
                    Id = 4,
                    Start = new TimeSpan(10, 20, 0),
                    End = new TimeSpan(11, 5, 0),
                    Number = 3
                },
                new()
                {
                    Id = 5,
                    Start = new TimeSpan(11, 15, 0),
                    End = new TimeSpan(12, 0, 0),
                    Number = 4
                },
                new()
                {
                    Id = 6,
                    Start = new TimeSpan(12, 10, 0),
                    End = new TimeSpan(12, 55, 0),
                    Number = 5
                },
                new()
                {
                    Id = 7,
                    Start = new TimeSpan(13, 5, 0),
                    End = new TimeSpan(13, 50, 0),
                    Number = 6
                },
                new()
                {
                    Id = 8,
                    Start = new TimeSpan(14, 0, 0),
                    End = new TimeSpan(14, 45, 0),
                    Number = 7
                },
                new()
                {
                    Id = 9,
                    Start = new TimeSpan(14, 50, 0),
                    End = new TimeSpan(15, 35, 0),
                    Number = 8
                },
                new()
                {
                    Id = 10,
                    Start = new TimeSpan(15, 40, 0),
                    End = new TimeSpan(16, 25, 0),
                    Number = 9
                },
                new()
                {
                    Id = 11,
                    Start = new TimeSpan(16, 30, 0),
                    End = new TimeSpan(17, 15, 0),
                    Number = 10
                },
                new()
                {
                    Id = 12,
                    Start = new TimeSpan(17, 20, 0),
                    End = new TimeSpan(18, 5, 0),
                    Number = 11
                },
                new()
                {
                    Id = 13,
                    Start = new TimeSpan(18, 10, 0),
                    End = new TimeSpan(18, 55, 0),
                    Number = 12
                },
                new()
                {
                    Id = 14,
                    Start = new TimeSpan(19, 00, 0),
                    End = new TimeSpan(19, 45, 0),
                    Number = 13
                }
            });
    }
}
