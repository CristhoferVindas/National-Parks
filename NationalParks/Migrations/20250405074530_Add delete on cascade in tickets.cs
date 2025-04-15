using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationalParks.Migrations
{
    /// <inheritdoc />
    public partial class Adddeleteoncascadeintickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "SalesXTickets_FK",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "SalesXTickets_FK",
                table: "Tickets",
                column: "TicketSale_Id",
                principalTable: "TicketSales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "SalesXTickets_FK",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "SalesXTickets_FK",
                table: "Tickets",
                column: "TicketSale_Id",
                principalTable: "TicketSales",
                principalColumn: "Id");
        }
    }
}
