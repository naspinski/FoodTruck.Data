using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class MadePriceTypeNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_PriceTypes_PriceTypeId",
                table: "Prices");

            migrationBuilder.AlterColumn<int>(
                name: "PriceTypeId",
                table: "Prices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_PriceTypes_PriceTypeId",
                table: "Prices",
                column: "PriceTypeId",
                principalTable: "PriceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_PriceTypes_PriceTypeId",
                table: "Prices");

            migrationBuilder.AlterColumn<int>(
                name: "PriceTypeId",
                table: "Prices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_PriceTypes_PriceTypeId",
                table: "Prices",
                column: "PriceTypeId",
                principalTable: "PriceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
