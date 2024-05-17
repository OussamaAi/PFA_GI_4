using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA.Migrations
{
    public partial class PFA115 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFermeture",
                table: "Endroits");

            migrationBuilder.DropColumn(
                name: "DateOuverture",
                table: "Endroits");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Endroits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFermeture",
                table: "Endroits",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOuverture",
                table: "Endroits",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Endroits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
