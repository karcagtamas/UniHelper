using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniHelper.Backend.Migrations
{
    public partial class LessonHourUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LessonHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(type: "int", nullable: false),
                    IsStart = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Start = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    End = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonHours", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LessonHours",
                columns: new[] { "Id", "End", "IsStart", "Number", "Start" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 8, 25, 0, 0), true, 0, new TimeSpan(0, 7, 40, 0, 0) },
                    { 2, new TimeSpan(0, 9, 15, 0, 0), true, 1, new TimeSpan(0, 8, 30, 0, 0) },
                    { 3, new TimeSpan(0, 10, 10, 0, 0), true, 2, new TimeSpan(0, 9, 25, 0, 0) },
                    { 4, new TimeSpan(0, 11, 5, 0, 0), true, 3, new TimeSpan(0, 10, 20, 0, 0) },
                    { 5, new TimeSpan(0, 12, 0, 0, 0), true, 4, new TimeSpan(0, 11, 15, 0, 0) },
                    { 6, new TimeSpan(0, 12, 55, 0, 0), true, 5, new TimeSpan(0, 12, 10, 0, 0) },
                    { 7, new TimeSpan(0, 13, 50, 0, 0), true, 6, new TimeSpan(0, 13, 5, 0, 0) },
                    { 8, new TimeSpan(0, 14, 45, 0, 0), true, 7, new TimeSpan(0, 14, 0, 0, 0) },
                    { 9, new TimeSpan(0, 15, 35, 0, 0), true, 8, new TimeSpan(0, 14, 50, 0, 0) },
                    { 10, new TimeSpan(0, 16, 25, 0, 0), true, 9, new TimeSpan(0, 15, 40, 0, 0) },
                    { 11, new TimeSpan(0, 17, 15, 0, 0), true, 10, new TimeSpan(0, 16, 30, 0, 0) },
                    { 12, new TimeSpan(0, 18, 5, 0, 0), true, 11, new TimeSpan(0, 17, 20, 0, 0) },
                    { 13, new TimeSpan(0, 18, 55, 0, 0), true, 12, new TimeSpan(0, 18, 10, 0, 0) },
                    { 14, new TimeSpan(0, 19, 45, 0, 0), true, 13, new TimeSpan(0, 19, 0, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonHours");
        }
    }
}
