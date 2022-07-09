using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Verrassingskalender_Api.Migrations
{
    public partial class RenameEntitiesToSingular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Grids_GridId",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Players_PlayerId",
                table: "Cells");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grids",
                table: "Grids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cells",
                table: "Cells");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "Grids",
                newName: "Grid");

            migrationBuilder.RenameTable(
                name: "Cells",
                newName: "Cell");

            migrationBuilder.RenameIndex(
                name: "IX_Cells_PlayerId",
                table: "Cell",
                newName: "IX_Cell_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cells_GridId",
                table: "Cell",
                newName: "IX_Cell_GridId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grid",
                table: "Grid",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cell",
                table: "Cell",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cell_Grid_GridId",
                table: "Cell",
                column: "GridId",
                principalTable: "Grid",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cell_Player_PlayerId",
                table: "Cell",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cell_Grid_GridId",
                table: "Cell");

            migrationBuilder.DropForeignKey(
                name: "FK_Cell_Player_PlayerId",
                table: "Cell");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grid",
                table: "Grid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cell",
                table: "Cell");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "Grid",
                newName: "Grids");

            migrationBuilder.RenameTable(
                name: "Cell",
                newName: "Cells");

            migrationBuilder.RenameIndex(
                name: "IX_Cell_PlayerId",
                table: "Cells",
                newName: "IX_Cells_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cell_GridId",
                table: "Cells",
                newName: "IX_Cells_GridId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grids",
                table: "Grids",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cells",
                table: "Cells",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Grids_GridId",
                table: "Cells",
                column: "GridId",
                principalTable: "Grids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Players_PlayerId",
                table: "Cells",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
