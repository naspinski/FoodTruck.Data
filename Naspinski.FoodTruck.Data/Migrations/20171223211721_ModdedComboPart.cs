using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class ModdedComboPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboParts_Categories_CategoryId",
                table: "ComboParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboParts_MenuItems_MenuItemId",
                table: "ComboParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboParts_MenuItems_ParentMenuItemId",
                table: "ComboParts");

            migrationBuilder.DropIndex(
                name: "IX_ComboParts_ParentMenuItemId",
                table: "ComboParts");

            migrationBuilder.DropColumn(
                name: "ParentMenuItemId",
                table: "ComboParts");

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId",
                table: "ComboParts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ComboParts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboParts_Categories_CategoryId",
                table: "ComboParts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboParts_MenuItems_MenuItemId",
                table: "ComboParts",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboParts_Categories_CategoryId",
                table: "ComboParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboParts_MenuItems_MenuItemId",
                table: "ComboParts");

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId",
                table: "ComboParts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ComboParts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ParentMenuItemId",
                table: "ComboParts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComboParts_ParentMenuItemId",
                table: "ComboParts",
                column: "ParentMenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComboParts_Categories_CategoryId",
                table: "ComboParts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboParts_MenuItems_MenuItemId",
                table: "ComboParts",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboParts_MenuItems_ParentMenuItemId",
                table: "ComboParts",
                column: "ParentMenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
