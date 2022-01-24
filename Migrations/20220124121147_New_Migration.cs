using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeForCoffee.Migrations
{
    public partial class New_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CafeBarista_Baristas_BaristaId",
                table: "CafeBarista");

            migrationBuilder.DropForeignKey(
                name: "FK_CafeBarista_Cafes_CafeId",
                table: "CafeBarista");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CafeBarista",
                table: "CafeBarista");

            migrationBuilder.RenameTable(
                name: "CafeBarista",
                newName: "CafeBaristas");

            migrationBuilder.RenameIndex(
                name: "IX_CafeBarista_CafeId",
                table: "CafeBaristas",
                newName: "IX_CafeBaristas_CafeId");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Cafes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CafeBaristas",
                table: "CafeBaristas",
                columns: new[] { "BaristaId", "CafeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CafeBaristas_Baristas_BaristaId",
                table: "CafeBaristas",
                column: "BaristaId",
                principalTable: "Baristas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CafeBaristas_Cafes_CafeId",
                table: "CafeBaristas",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CafeBaristas_Baristas_BaristaId",
                table: "CafeBaristas");

            migrationBuilder.DropForeignKey(
                name: "FK_CafeBaristas_Cafes_CafeId",
                table: "CafeBaristas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CafeBaristas",
                table: "CafeBaristas");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Cafes");

            migrationBuilder.RenameTable(
                name: "CafeBaristas",
                newName: "CafeBarista");

            migrationBuilder.RenameIndex(
                name: "IX_CafeBaristas_CafeId",
                table: "CafeBarista",
                newName: "IX_CafeBarista_CafeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CafeBarista",
                table: "CafeBarista",
                columns: new[] { "BaristaId", "CafeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CafeBarista_Baristas_BaristaId",
                table: "CafeBarista",
                column: "BaristaId",
                principalTable: "Baristas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CafeBarista_Cafes_CafeId",
                table: "CafeBarista",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
