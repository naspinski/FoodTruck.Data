using Microsoft.EntityFrameworkCore.Migrations;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class addingorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Settings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Settings");
        }
    }
}
