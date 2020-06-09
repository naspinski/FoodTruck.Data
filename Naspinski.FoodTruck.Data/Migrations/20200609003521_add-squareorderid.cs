using Microsoft.EntityFrameworkCore.Migrations;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class addsquareorderid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SquareOrderId",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SquareOrderId",
                table: "Orders");
        }
    }
}
