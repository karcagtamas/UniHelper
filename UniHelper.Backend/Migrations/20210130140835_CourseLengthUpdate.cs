using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniHelper.Backend.Migrations
{
    public partial class CourseLengthUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Courses");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "End",
                table: "Courses",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Start",
                table: "Courses",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
