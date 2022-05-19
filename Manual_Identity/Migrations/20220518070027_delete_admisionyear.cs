using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manual_Identity.Migrations
{
    public partial class delete_admisionyear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdmissionYear",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AdmissionYear",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
