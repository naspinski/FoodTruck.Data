using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class SettingsTyping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Settings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Settings");
        }
    }
}
