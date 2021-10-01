using Microsoft.EntityFrameworkCore.Migrations;

namespace Cars.Domain.Migrations
{
    public partial class PlaceEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Place",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Place",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfGarages",
                table: "Place",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Place",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "NumberOfGarages",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Place");
        }
    }
}
