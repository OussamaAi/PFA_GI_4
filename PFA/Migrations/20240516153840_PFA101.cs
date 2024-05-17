using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA.Migrations
{
    public partial class PFA101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomHotel",
                table: "Endroits");

            migrationBuilder.DropColumn(
                name: "NomRestaurant",
                table: "Endroits");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<float>(
                name: "NbrEtoile",
                table: "Endroits",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Addresse",
                table: "Endroits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomEndroit",
                table: "Endroits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Endroits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addresse",
                table: "Endroits");

            migrationBuilder.DropColumn(
                name: "NomEndroit",
                table: "Endroits");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Endroits");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NbrEtoile",
                table: "Endroits",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "NomHotel",
                table: "Endroits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomRestaurant",
                table: "Endroits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
