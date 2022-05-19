using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manual_Identity.Migrations
{
    public partial class coursename_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Students");
        }
    }
}
