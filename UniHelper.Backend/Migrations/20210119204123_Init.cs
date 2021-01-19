using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniHelper.Backend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalNotes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Text = table.Column<string>(type: "varchar(240) CHARACTER SET utf8mb4", maxLength: 240, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsClosed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlobalTasks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Text = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsSolved = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodNotes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    PeriodId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Text = table.Column<string>(type: "varchar(240) CHARACTER SET utf8mb4", maxLength: 240, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsClosed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodNotes_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeriodTasks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    PeriodId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Text = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsSolved = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodTasks_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    LongName = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: false),
                    Code = table.Column<string>(type: "varchar(10) CHARACTER SET utf8mb4", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    FolderName = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: false),
                    PeriodId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Place = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: false),
                    Start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    End = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Day = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: false),
                    Teachers = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsSelected = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SubjectId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectNotes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    SubjectId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Text = table.Column<string>(type: "varchar(240) CHARACTER SET utf8mb4", maxLength: 240, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsClosed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectNotes_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTasks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    SubjectId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Text = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsSolved = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectTasks_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubjectId",
                table: "Courses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodNotes_PeriodId",
                table: "PeriodNotes",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodTasks_PeriodId",
                table: "PeriodTasks",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectNotes_SubjectId",
                table: "SubjectNotes",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_PeriodId",
                table: "Subjects",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTasks_SubjectId",
                table: "SubjectTasks",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "GlobalNotes");

            migrationBuilder.DropTable(
                name: "GlobalTasks");

            migrationBuilder.DropTable(
                name: "PeriodNotes");

            migrationBuilder.DropTable(
                name: "PeriodTasks");

            migrationBuilder.DropTable(
                name: "SubjectNotes");

            migrationBuilder.DropTable(
                name: "SubjectTasks");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Periods");
        }
    }
}
