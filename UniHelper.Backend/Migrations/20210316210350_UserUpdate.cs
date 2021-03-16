using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniHelper.Backend.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Periods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GlobalTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GlobalNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "varchar(120) CHARACTER SET utf8mb4", maxLength: 120, nullable: false),
                    UserName = table.Column<string>(type: "varchar(80) CHARACTER SET utf8mb4", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Registration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Periods_UserId",
                table: "Periods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalTasks_UserId",
                table: "GlobalTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalNotes_UserId",
                table: "GlobalNotes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GlobalNotes_Users_UserId",
                table: "GlobalNotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GlobalTasks_Users_UserId",
                table: "GlobalTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_Users_UserId",
                table: "Periods",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlobalNotes_Users_UserId",
                table: "GlobalNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_GlobalTasks_Users_UserId",
                table: "GlobalTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Periods_Users_UserId",
                table: "Periods");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Periods_UserId",
                table: "Periods");

            migrationBuilder.DropIndex(
                name: "IX_GlobalTasks_UserId",
                table: "GlobalTasks");

            migrationBuilder.DropIndex(
                name: "IX_GlobalNotes_UserId",
                table: "GlobalNotes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GlobalTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GlobalNotes");
        }
    }
}
