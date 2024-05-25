using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA.Migrations
{
    public partial class PFA02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Users_UserId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_UserId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Visits");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ClientId",
                table: "Visits",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Users_ClientId",
                table: "Visits",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Users_ClientId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_ClientId",
                table: "Visits");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_UserId",
                table: "Visits",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Users_UserId",
                table: "Visits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
