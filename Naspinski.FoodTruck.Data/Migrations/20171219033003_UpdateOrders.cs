using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class UpdateOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTransactionComplete",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsTransactionComplete",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }
    }
}
