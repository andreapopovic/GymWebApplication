using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prihvacen",
                table: "Zahtev",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrenerIme",
                table: "Zahtev",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrenerPrezime",
                table: "Zahtev",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ProbniTermin",
                table: "ClanTeretane",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prihvacen",
                table: "Zahtev");

            migrationBuilder.DropColumn(
                name: "TrenerIme",
                table: "Zahtev");

            migrationBuilder.DropColumn(
                name: "TrenerPrezime",
                table: "Zahtev");

            migrationBuilder.DropColumn(
                name: "ProbniTermin",
                table: "ClanTeretane");
        }
    }
}
