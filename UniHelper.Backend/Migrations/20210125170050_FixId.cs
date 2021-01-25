using Microsoft.EntityFrameworkCore.Migrations;

namespace UniHelper.Backend.Migrations
{
    public partial class FixId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Subjects_SubjectId1",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_PeriodNotes_Periods_PeriodId1",
                table: "PeriodNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_PeriodTasks_Periods_PeriodId1",
                table: "PeriodTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectNotes_Subjects_SubjectId1",
                table: "SubjectNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Periods_PeriodId1",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTasks_Subjects_SubjectId1",
                table: "SubjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTasks_SubjectId1",
                table: "SubjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_PeriodId1",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_SubjectNotes_SubjectId1",
                table: "SubjectNotes");

            migrationBuilder.DropIndex(
                name: "IX_PeriodTasks_PeriodId1",
                table: "PeriodTasks");

            migrationBuilder.DropIndex(
                name: "IX_PeriodNotes_PeriodId1",
                table: "PeriodNotes");

            migrationBuilder.DropIndex(
                name: "IX_Courses_SubjectId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SubjectId1",
                table: "SubjectTasks");

            migrationBuilder.DropColumn(
                name: "PeriodId1",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectId1",
                table: "SubjectNotes");

            migrationBuilder.DropColumn(
                name: "PeriodId1",
                table: "PeriodTasks");

            migrationBuilder.DropColumn(
                name: "PeriodId1",
                table: "PeriodNotes");

            migrationBuilder.DropColumn(
                name: "SubjectId1",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "SubjectTasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "Subjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "SubjectNotes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "PeriodTasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "PeriodNotes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTasks_SubjectId",
                table: "SubjectTasks",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_PeriodId",
                table: "Subjects",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectNotes_SubjectId",
                table: "SubjectNotes",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodTasks_PeriodId",
                table: "PeriodTasks",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodNotes_PeriodId",
                table: "PeriodNotes",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubjectId",
                table: "Courses",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Subjects_SubjectId",
                table: "Courses",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodNotes_Periods_PeriodId",
                table: "PeriodNotes",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodTasks_Periods_PeriodId",
                table: "PeriodTasks",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectNotes_Subjects_SubjectId",
                table: "SubjectNotes",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Periods_PeriodId",
                table: "Subjects",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTasks_Subjects_SubjectId",
                table: "SubjectTasks",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Subjects_SubjectId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_PeriodNotes_Periods_PeriodId",
                table: "PeriodNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_PeriodTasks_Periods_PeriodId",
                table: "PeriodTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectNotes_Subjects_SubjectId",
                table: "SubjectNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Periods_PeriodId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTasks_Subjects_SubjectId",
                table: "SubjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTasks_SubjectId",
                table: "SubjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_PeriodId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_SubjectNotes_SubjectId",
                table: "SubjectNotes");

            migrationBuilder.DropIndex(
                name: "IX_PeriodTasks_PeriodId",
                table: "PeriodTasks");

            migrationBuilder.DropIndex(
                name: "IX_PeriodNotes_PeriodId",
                table: "PeriodNotes");

            migrationBuilder.DropIndex(
                name: "IX_Courses_SubjectId",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "SubjectTasks",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId1",
                table: "SubjectTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PeriodId",
                table: "Subjects",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PeriodId1",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "SubjectNotes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId1",
                table: "SubjectNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PeriodId",
                table: "PeriodTasks",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PeriodId1",
                table: "PeriodTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PeriodId",
                table: "PeriodNotes",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PeriodId1",
                table: "PeriodNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "Courses",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId1",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTasks_SubjectId1",
                table: "SubjectTasks",
                column: "SubjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_PeriodId1",
                table: "Subjects",
                column: "PeriodId1");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectNotes_SubjectId1",
                table: "SubjectNotes",
                column: "SubjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodTasks_PeriodId1",
                table: "PeriodTasks",
                column: "PeriodId1");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodNotes_PeriodId1",
                table: "PeriodNotes",
                column: "PeriodId1");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubjectId1",
                table: "Courses",
                column: "SubjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Subjects_SubjectId1",
                table: "Courses",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodNotes_Periods_PeriodId1",
                table: "PeriodNotes",
                column: "PeriodId1",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodTasks_Periods_PeriodId1",
                table: "PeriodTasks",
                column: "PeriodId1",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectNotes_Subjects_SubjectId1",
                table: "SubjectNotes",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Periods_PeriodId1",
                table: "Subjects",
                column: "PeriodId1",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTasks_Subjects_SubjectId1",
                table: "SubjectTasks",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
