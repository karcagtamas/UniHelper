﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniHelper.Backend;

namespace UniHelper.Backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210201085328_LessonHourFix")]
    partial class LessonHourFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("UniHelper.Backend.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Teachers")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.GlobalNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("GlobalNotes");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.GlobalTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsSolved")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("GlobalTasks");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.LessonHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time(6)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.ToTable("LessonHours");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            End = new TimeSpan(0, 8, 25, 0, 0),
                            Number = 0,
                            Start = new TimeSpan(0, 7, 40, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            End = new TimeSpan(0, 9, 15, 0, 0),
                            Number = 1,
                            Start = new TimeSpan(0, 8, 30, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            End = new TimeSpan(0, 10, 10, 0, 0),
                            Number = 2,
                            Start = new TimeSpan(0, 9, 25, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            End = new TimeSpan(0, 11, 5, 0, 0),
                            Number = 3,
                            Start = new TimeSpan(0, 10, 20, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            End = new TimeSpan(0, 12, 0, 0, 0),
                            Number = 4,
                            Start = new TimeSpan(0, 11, 15, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            End = new TimeSpan(0, 12, 55, 0, 0),
                            Number = 5,
                            Start = new TimeSpan(0, 12, 10, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            End = new TimeSpan(0, 13, 50, 0, 0),
                            Number = 6,
                            Start = new TimeSpan(0, 13, 5, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            End = new TimeSpan(0, 14, 45, 0, 0),
                            Number = 7,
                            Start = new TimeSpan(0, 14, 0, 0, 0)
                        },
                        new
                        {
                            Id = 9,
                            End = new TimeSpan(0, 15, 35, 0, 0),
                            Number = 8,
                            Start = new TimeSpan(0, 14, 50, 0, 0)
                        },
                        new
                        {
                            Id = 10,
                            End = new TimeSpan(0, 16, 25, 0, 0),
                            Number = 9,
                            Start = new TimeSpan(0, 15, 40, 0, 0)
                        },
                        new
                        {
                            Id = 11,
                            End = new TimeSpan(0, 17, 15, 0, 0),
                            Number = 10,
                            Start = new TimeSpan(0, 16, 30, 0, 0)
                        },
                        new
                        {
                            Id = 12,
                            End = new TimeSpan(0, 18, 5, 0, 0),
                            Number = 11,
                            Start = new TimeSpan(0, 17, 20, 0, 0)
                        },
                        new
                        {
                            Id = 13,
                            End = new TimeSpan(0, 18, 55, 0, 0),
                            Number = 12,
                            Start = new TimeSpan(0, 18, 10, 0, 0)
                        },
                        new
                        {
                            Id = 14,
                            End = new TimeSpan(0, 19, 45, 0, 0),
                            Number = 13,
                            Start = new TimeSpan(0, 19, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.Period", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.PeriodNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.ToTable("PeriodNotes");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.PeriodTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsSolved")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.ToTable("PeriodTasks");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16) CHARACTER SET utf8mb4");

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LongName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<int?>("Result")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.SubjectNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectNotes");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.SubjectTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsSolved")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectTasks");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.Course", b =>
                {
                    b.HasOne("UniHelper.Backend.Entities.Subject", "Subject")
                        .WithMany("Courses")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.PeriodNote", b =>
                {
                    b.HasOne("UniHelper.Backend.Entities.Period", "Period")
                        .WithMany("Notes")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Period");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.PeriodTask", b =>
                {
                    b.HasOne("UniHelper.Backend.Entities.Period", "Period")
                        .WithMany("Tasks")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Period");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.Subject", b =>
                {
                    b.HasOne("UniHelper.Backend.Entities.Period", "Period")
                        .WithMany("Subjects")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Period");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.SubjectNote", b =>
                {
                    b.HasOne("UniHelper.Backend.Entities.Subject", "Subject")
                        .WithMany("Notes")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.SubjectTask", b =>
                {
                    b.HasOne("UniHelper.Backend.Entities.Subject", "Subject")
                        .WithMany("Tasks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.Period", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("Subjects");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("UniHelper.Backend.Entities.Subject", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Notes");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
