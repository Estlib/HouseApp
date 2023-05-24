using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseApp.Data.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SquareMeters = table.Column<double>(type: "float", nullable: false),
                    HouseColours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoofType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalRoomCount = table.Column<int>(type: "int", nullable: false),
                    BathroomCount = table.Column<int>(type: "int", nullable: false),
                    BedroomCount = table.Column<int>(type: "int", nullable: false),
                    IsForRentOrSale = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    BuildingAge = table.Column<int>(type: "int", nullable: false),
                    BuiltAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FloorCount = table.Column<int>(type: "int", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
