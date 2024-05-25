using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA.Migrations
{
    public partial class PFA0004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypePaiment",
                table: "Paiments",
                newName: "NumeroDeCarte");

            migrationBuilder.AddColumn<string>(
                name: "CVV",
                table: "Paiments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateExpiration",
                table: "Paiments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Paiments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "Paiments");

            migrationBuilder.DropColumn(
                name: "DateExpiration",
                table: "Paiments");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Paiments");

            migrationBuilder.RenameColumn(
                name: "NumeroDeCarte",
                table: "Paiments",
                newName: "TypePaiment");
        }
    }
}
