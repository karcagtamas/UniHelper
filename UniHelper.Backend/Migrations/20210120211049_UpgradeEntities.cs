using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniHelper.Backend.Migrations
{
    public partial class UpgradeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "SubjectTasks",
                type: "varchar(200) CHARACTER SET utf8mb4",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "PeriodTasks",
                type: "varchar(200) CHARACTER SET utf8mb4",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Periods",
                type: "varchar(20) CHARACTER SET utf8mb4",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "GlobalTasks",
                type: "varchar(200) CHARACTER SET utf8mb4",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Start",
                table: "Courses",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "End",
                table: "Courses",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<int>(
                name: "Day",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20) CHARACTER SET utf8mb4",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "SubjectTasks",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200) CHARACTER SET utf8mb4",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "PeriodTasks",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200) CHARACTER SET utf8mb4",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Periods",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20) CHARACTER SET utf8mb4",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "GlobalTasks",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200) CHARACTER SET utf8mb4",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "Courses",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Courses",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Day",
                table: "Courses",
                type: "varchar(20) CHARACTER SET utf8mb4",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
