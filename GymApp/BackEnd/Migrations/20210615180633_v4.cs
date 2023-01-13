using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trener_TreneriTreninga_TreneriTreningaID",
                table: "Trener");

            migrationBuilder.DropForeignKey(
                name: "FK_Trening_TreninziTrenera_TreninziTreneraID",
                table: "Trening");

            migrationBuilder.DropTable(
                name: "TreneriTreninga");

            migrationBuilder.DropTable(
                name: "TreninziTrenera");

            migrationBuilder.DropIndex(
                name: "IX_Trening_TreninziTreneraID",
                table: "Trening");

            migrationBuilder.DropIndex(
                name: "IX_Trener_TreneriTreningaID",
                table: "Trener");

            migrationBuilder.DropColumn(
                name: "TreninziTreneraID",
                table: "Trening");

            migrationBuilder.DropColumn(
                name: "TreneriTreningaID",
                table: "Trener");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreninziTreneraID",
                table: "Trening",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreneriTreningaID",
                table: "Trener",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TreneriTreninga",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivTrening = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreneriTreninga", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TreninziTrenera",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoImeTrenera = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreninziTrenera", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trening_TreninziTreneraID",
                table: "Trening",
                column: "TreninziTreneraID");

            migrationBuilder.CreateIndex(
                name: "IX_Trener_TreneriTreningaID",
                table: "Trener",
                column: "TreneriTreningaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trener_TreneriTreninga_TreneriTreningaID",
                table: "Trener",
                column: "TreneriTreningaID",
                principalTable: "TreneriTreninga",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trening_TreninziTrenera_TreninziTreneraID",
                table: "Trening",
                column: "TreninziTreneraID",
                principalTable: "TreninziTrenera",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
