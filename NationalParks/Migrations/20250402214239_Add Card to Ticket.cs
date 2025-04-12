using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationalParks.Migrations
{
    /// <inheritdoc />
    public partial class AddCardtoTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardType",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PlaceName",
                table: "PlaceRating");

            migrationBuilder.AddColumn<int>(
                name: "cardId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_cardId",
                table: "Tickets",
                column: "cardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Card_cardId",
                table: "Tickets",
                column: "cardId",
                principalTable: "Card",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Card_cardId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_cardId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "cardId",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "CardType",
                table: "Tickets",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlaceName",
                table: "PlaceRating",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
