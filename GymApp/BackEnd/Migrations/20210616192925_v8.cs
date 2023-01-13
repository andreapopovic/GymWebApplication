using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumIVreme",
                table: "Termin");

            migrationBuilder.AddColumn<string>(
                name: "Datum",
                table: "Termin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImeTrenera",
                table: "Termin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrezimeTrenera",
                table: "Termin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VremeKraja",
                table: "Termin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VremePocetka",
                table: "Termin",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "ImeTrenera",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "PrezimeTrenera",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "VremeKraja",
                table: "Termin");

            migrationBuilder.DropColumn(
                name: "VremePocetka",
                table: "Termin");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumIVreme",
                table: "Termin",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
