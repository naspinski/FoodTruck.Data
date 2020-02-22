using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Naspinski.FoodTruck.Data.Migrations
{
    public partial class AddDeliveryDestination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryDestinations",
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
                    Value = table.Column<string>(nullable: false),
                    IsCity = table.Column<bool>(nullable: false),
                    IsBlacklist = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDestinations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryDestinations");
        }
    }
}
