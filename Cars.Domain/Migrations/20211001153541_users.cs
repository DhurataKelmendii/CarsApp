using Microsoft.EntityFrameworkCore.Migrations;

namespace Cars.Domain.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "ApplicationUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "City",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ApplicationUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
