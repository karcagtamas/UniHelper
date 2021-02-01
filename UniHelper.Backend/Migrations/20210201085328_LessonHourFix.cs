using Microsoft.EntityFrameworkCore.Migrations;

namespace UniHelper.Backend.Migrations
{
    public partial class LessonHourFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStart",
                table: "LessonHours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStart",
                table: "LessonHours",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsStart",
                value: true);

            migrationBuilder.UpdateData(
                table: "LessonHours",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsStart",
                value: true);
        }
    }
}
