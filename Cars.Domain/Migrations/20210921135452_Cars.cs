using Microsoft.EntityFrameworkCore.Migrations;

namespace Cars.Domain.Migrations
{
    public partial class Cars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarGarageRel_Car_CarId",
                table: "CarGarageRel");

            migrationBuilder.DropForeignKey(
                name: "FK_CarGarageRel_Garage_GarageId",
                table: "CarGarageRel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCarRel_Car_CarId",
                table: "UserCarRel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCarRel_User_UserId",
                table: "UserCarRel");

            migrationBuilder.DropIndex(
                name: "IX_UserCarRel_CarId",
                table: "UserCarRel");

            migrationBuilder.DropIndex(
                name: "IX_UserCarRel_UserId",
                table: "UserCarRel");

            migrationBuilder.DropIndex(
                name: "IX_CarGarageRel_CarId",
                table: "CarGarageRel");

            migrationBuilder.DropIndex(
                name: "IX_CarGarageRel_GarageId",
                table: "CarGarageRel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserCarRel_CarId",
                table: "UserCarRel",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCarRel_UserId",
                table: "UserCarRel",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserCarRel_Car_CarId",
                table: "UserCarRel",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCarRel_User_UserId",
                table: "UserCarRel",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
