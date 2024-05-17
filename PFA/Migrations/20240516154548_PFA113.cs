using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA.Migrations
{
    public partial class PFA113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Endroits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Endroits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
