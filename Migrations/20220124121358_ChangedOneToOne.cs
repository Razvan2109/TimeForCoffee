using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeForCoffee.Migrations
{
    public partial class ChangedOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Cafes_Id",
                table: "Locations");

            migrationBuilder.CreateIndex(
                name: "IX_Cafes_LocationId",
                table: "Cafes",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cafes_Locations_LocationId",
                table: "Cafes",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafes_Locations_LocationId",
                table: "Cafes");

            migrationBuilder.DropIndex(
                name: "IX_Cafes_LocationId",
                table: "Cafes");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Cafes_Id",
                table: "Locations",
                column: "Id",
                principalTable: "Cafes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
