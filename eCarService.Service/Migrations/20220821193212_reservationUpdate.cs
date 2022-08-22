using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCarService.Service.Migrations
{
    public partial class reservationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "Payments",
                newName: "TransactionId");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Payments",
                newName: "CardNumber");
        }
    }
}
