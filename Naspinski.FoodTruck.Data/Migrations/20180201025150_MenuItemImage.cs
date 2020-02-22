using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class MenuItemImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_ImageId",
                table: "MenuItems",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Images_ImageId",
                table: "MenuItems",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Images_ImageId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_ImageId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "MenuItems");
        }
    }
}
