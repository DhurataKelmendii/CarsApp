using Microsoft.EntityFrameworkCore.Migrations;

namespace Cars.Domain.Migrations
{
    public partial class CarGarageUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CarGarageRel_CarId",
                table: "CarGarageRel",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarGarageRel_GarageId",
                table: "CarGarageRel",
                column: "GarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarGarageRel_Car_CarId",
                table: "CarGarageRel",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarGarageRel_Garage_GarageId",
                table: "CarGarageRel",
                column: "GarageId",
                principalTable: "Garage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarGarageRel_Car_CarId",
                table: "CarGarageRel");

            migrationBuilder.DropForeignKey(
                name: "FK_CarGarageRel_Garage_GarageId",
                table: "CarGarageRel");

            migrationBuilder.DropIndex(
                name: "IX_CarGarageRel_CarId",
                table: "CarGarageRel");

            migrationBuilder.DropIndex(
                name: "IX_CarGarageRel_GarageId",
                table: "CarGarageRel");
        }
    }
}
