using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TerminID",
                table: "ClanTeretane",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClanTeretane_TerminID",
                table: "ClanTeretane",
                column: "TerminID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClanTeretane_Termin_TerminID",
                table: "ClanTeretane",
                column: "TerminID",
                principalTable: "Termin",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClanTeretane_Termin_TerminID",
                table: "ClanTeretane");

            migrationBuilder.DropIndex(
                name: "IX_ClanTeretane_TerminID",
                table: "ClanTeretane");

            migrationBuilder.DropColumn(
                name: "TerminID",
                table: "ClanTeretane");
        }
    }
}
