using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class TrasnsactionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsTransactionComplete",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsTransactionComplete",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }
    }
}
