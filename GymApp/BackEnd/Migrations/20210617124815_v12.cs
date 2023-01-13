using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClanTeretane_Termin_TerminID",
                table: "ClanTeretane");

            migrationBuilder.DropForeignKey(
                name: "FK_Trening_ClanTeretane_ClanTeretaneID",
                table: "Trening");

            migrationBuilder.DropIndex(
                name: "IX_Trening_ClanTeretaneID",
                table: "Trening");

            migrationBuilder.DropIndex(
                name: "IX_ClanTeretane_TerminID",
                table: "ClanTeretane");

            migrationBuilder.DropColumn(
                name: "ClanTeretaneID",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "TerminID",
                table: "ClanTeretane");

            migrationBuilder.CreateTable(
                name: "ClanoviTermini",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanoviId = table.Column<int>(type: "int", nullable: false),
                    TerminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanoviTermini", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClanoviTermini");

            migrationBuilder.AddColumn<int>(
                name: "ClanTeretaneID",
                table: "Trening",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TerminID",
                table: "ClanTeretane",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trening_ClanTeretaneID",
                table: "Trening",
                column: "ClanTeretaneID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Trening_ClanTeretane_ClanTeretaneID",
                table: "Trening",
                column: "ClanTeretaneID",
                principalTable: "ClanTeretane",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
