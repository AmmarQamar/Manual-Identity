using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manual_Identity.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseViewModelCourseId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CourseViewModelCourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseViewModelCourseId",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseViewModelCourseId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseViewModelCourseId",
                table: "Students",
                column: "CourseViewModelCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseViewModelCourseId",
                table: "Students",
                column: "CourseViewModelCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");
        }
    }
}
