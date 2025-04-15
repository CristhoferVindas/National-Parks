using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationalParks.Migrations
{
    /// <inheritdoc />
    public partial class Removeplace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceName",
                table: "PlaceRatings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlaceName",
                table: "PlaceRatings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
