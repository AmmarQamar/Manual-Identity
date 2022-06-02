using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manual_Identity.Migrations
{
    public partial class add_salesmain1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesMain",
                table: "SalesMain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales_Item",
                table: "Sales_Item");

            migrationBuilder.RenameTable(
                name: "SalesMain",
                newName: "SalesMains");

            migrationBuilder.RenameTable(
                name: "Sales_Item",
                newName: "Sales_Items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesMains",
                table: "SalesMains",
                column: "SalesMain_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales_Items",
                table: "Sales_Items",
                column: "SalesItem_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesMains",
                table: "SalesMains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales_Items",
                table: "Sales_Items");

            migrationBuilder.RenameTable(
                name: "SalesMains",
                newName: "SalesMain");

            migrationBuilder.RenameTable(
                name: "Sales_Items",
                newName: "Sales_Item");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesMain",
                table: "SalesMain",
                column: "SalesMain_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales_Item",
                table: "Sales_Item",
                column: "SalesItem_Id");
        }
    }
}
