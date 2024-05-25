using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA.Migrations
{
    public partial class PFA01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chambress_Reservations_ReservationId",
                table: "Chambress");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Reservations_ReservationId",
                table: "Tables");

            migrationBuilder.AddForeignKey(
                name: "FK_Chambress_Reservations_ReservationId",
                table: "Chambress",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Reservations_ReservationId",
                table: "Tables",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chambress_Reservations_ReservationId",
                table: "Chambress");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Reservations_ReservationId",
                table: "Tables");

            migrationBuilder.AddForeignKey(
                name: "FK_Chambress_Reservations_ReservationId",
                table: "Chambress",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Reservations_ReservationId",
                table: "Tables",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
