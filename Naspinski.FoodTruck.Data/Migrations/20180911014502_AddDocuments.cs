using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class AddDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "FoodTruck");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Updated = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Deleted = table.Column<DateTimeOffset>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                nullable: true,
                defaultValue: "FoodTruck",
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
