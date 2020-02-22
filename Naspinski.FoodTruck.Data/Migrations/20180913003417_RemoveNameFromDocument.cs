using Microsoft.EntityFrameworkCore.Migrations;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class RemoveNameFromDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Documents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Documents",
                nullable: false,
                defaultValue: "");
        }
    }
}
