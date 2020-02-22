using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class AddingPriceTypeConnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Prices");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Prices",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Prices");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Prices",
                nullable: false,
                defaultValue: "");
        }
    }
}
