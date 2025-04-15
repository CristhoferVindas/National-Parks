using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationalParks.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLocationfromPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceRatings_Places_PlaceId",
                table: "PlaceRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Locations_LocationId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_SiteTypes_SiteTypeId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Places_PlaceId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketSales_TicketSaleId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketSales_Cards_CardId",
                table: "TicketSales");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketSales_Visitors_VisitorId",
                table: "TicketSales");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Countries_CountryId",
                table: "Visitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visitors",
                table: "Visitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketSales",
                table: "TicketSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Species",
                table: "Species");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlacesXSpecies",
                table: "PlacesXSpecies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiteTypes",
                table: "SiteTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaceRatings",
                table: "PlaceRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PassportOrId",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "TicketSales");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "SiteTypes");

            migrationBuilder.RenameTable(
                name: "SiteTypes",
                newName: "SiteType");

            migrationBuilder.RenameTable(
                name: "PlaceRatings",
                newName: "PlaceRating");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Visitors",
                newName: "Country_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Visitors_CountryId",
                table: "Visitors",
                newName: "IX_Visitors_Country_Id");

            migrationBuilder.RenameColumn(
                name: "VisitorId",
                table: "TicketSales",
                newName: "Visitor_Id");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "TicketSales",
                newName: "Card_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSales_VisitorId",
                table: "TicketSales",
                newName: "IX_TicketSales_Visitor_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSales_CardId",
                table: "TicketSales",
                newName: "IX_TicketSales_Card_Id");

            migrationBuilder.RenameColumn(
                name: "TicketSaleId",
                table: "Tickets",
                newName: "TicketSale_Id");

            migrationBuilder.RenameColumn(
                name: "PlaceId",
                table: "Tickets",
                newName: "Place_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketSaleId",
                table: "Tickets",
                newName: "IX_Tickets_TicketSale_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_PlaceId",
                table: "Tickets",
                newName: "IX_Tickets_Place_Id");

            migrationBuilder.RenameColumn(
                name: "SiteTypeId",
                table: "Places",
                newName: "SiteType_Id");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Places",
                newName: "Location_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Places_SiteTypeId",
                table: "Places",
                newName: "IX_Places_SiteType_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Places_LocationId",
                table: "Places",
                newName: "IX_Places_Location_Id");

            migrationBuilder.RenameColumn(
                name: "PlaceId",
                table: "PlaceRating",
                newName: "Place_Id");

            migrationBuilder.RenameIndex(
                name: "IX_PlaceRatings_PlaceId",
                table: "PlaceRating",
                newName: "IX_PlaceRating_Place_Id");

            migrationBuilder.AlterColumn<string>(
                name: "VisitReason",
                table: "Visitors",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Visitors",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Visitors",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Visitors",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "Visitors",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "BirthCountry",
                table: "Visitors",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Country_Id",
                table: "Visitors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IDNumberOrPassport",
                table: "Visitors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "TicketSales",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "SaleDate",
                table: "TicketSales",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "TicketSales",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Visitor_Id",
                table: "TicketSales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Card_Id",
                table: "TicketSales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "TicketSales",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "SaleDate",
                table: "Tickets",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Commission",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "Tickets",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TicketSale_Id",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Place_Id",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Tickets",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Species",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesType",
                table: "Species",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SpecialCharacteristics",
                table: "Species",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ScientificName",
                table: "Species",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Species",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommonName",
                table: "Species",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReservedArea",
                table: "Places",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Recognitions",
                table: "Places",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Places",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Places",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Places",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Coordinates",
                table: "Places",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Places",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SiteType_Id",
                table: "Places",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Location_Id",
                table: "Places",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "SiteType",
                table: "Places",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SiteType",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "PlaceRating",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Place_Id",
                table: "PlaceRating",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PlaceName",
                table: "PlaceRating",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Location",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "Location",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Canton",
                table: "Location",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Country",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Continent",
                table: "Country",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Commission",
                table: "Card",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "Card",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "Visitors_PK",
                table: "Visitors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "TicketSales_PK",
                table: "TicketSales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Ticket_PK",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Species_PK",
                table: "Species",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PlacesXSpecies_PK",
                table: "PlacesXSpecies",
                columns: new[] { "SpeciesId", "PlaceId" });

            migrationBuilder.AddPrimaryKey(
                name: "Places_PK",
                table: "Places",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "SiteType_PK",
                table: "SiteType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PlaceRating_PK",
                table: "PlaceRating",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Location_PK",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Country_PK",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Card_PK",
                table: "Card",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlacesXSpecies_PlaceId",
                table: "PlacesXSpecies",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "PlacesXPlaceRating_FK",
                table: "PlaceRating",
                column: "Place_Id",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "PlacesXLocation_FK",
                table: "Places",
                column: "Location_Id",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "SiteTypeXPlaces_FK",
                table: "Places",
                column: "SiteType_Id",
                principalTable: "SiteType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "PlacesXSpecies_FK1",
                table: "PlacesXSpecies",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "PlacesXSpecies_FK2",
                table: "PlacesXSpecies",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "PlacesXTickets_FK",
                table: "Tickets",
                column: "Place_Id",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "SalesXTickets_FK",
                table: "Tickets",
                column: "TicketSale_Id",
                principalTable: "TicketSales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "SalesXCardCommission_FK",
                table: "TicketSales",
                column: "Card_Id",
                principalTable: "Card",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "SalesXVisitors_FK",
                table: "TicketSales",
                column: "Visitor_Id",
                principalTable: "Visitors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "VisitorsXCountry_FK",
                table: "Visitors",
                column: "Country_Id",
                principalTable: "Country",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "PlacesXPlaceRating_FK",
                table: "PlaceRating");

            migrationBuilder.DropForeignKey(
                name: "PlacesXLocation_FK",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "SiteTypeXPlaces_FK",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "PlacesXSpecies_FK1",
                table: "PlacesXSpecies");

            migrationBuilder.DropForeignKey(
                name: "PlacesXSpecies_FK2",
                table: "PlacesXSpecies");

            migrationBuilder.DropForeignKey(
                name: "PlacesXTickets_FK",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "SalesXTickets_FK",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "SalesXCardCommission_FK",
                table: "TicketSales");

            migrationBuilder.DropForeignKey(
                name: "SalesXVisitors_FK",
                table: "TicketSales");

            migrationBuilder.DropForeignKey(
                name: "VisitorsXCountry_FK",
                table: "Visitors");

            migrationBuilder.DropPrimaryKey(
                name: "Visitors_PK",
                table: "Visitors");

            migrationBuilder.DropPrimaryKey(
                name: "TicketSales_PK",
                table: "TicketSales");

            migrationBuilder.DropPrimaryKey(
                name: "Ticket_PK",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "Species_PK",
                table: "Species");

            migrationBuilder.DropPrimaryKey(
                name: "PlacesXSpecies_PK",
                table: "PlacesXSpecies");

            migrationBuilder.DropIndex(
                name: "IX_PlacesXSpecies_PlaceId",
                table: "PlacesXSpecies");

            migrationBuilder.DropPrimaryKey(
                name: "Places_PK",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "SiteType_PK",
                table: "SiteType");

            migrationBuilder.DropPrimaryKey(
                name: "PlaceRating_PK",
                table: "PlaceRating");

            migrationBuilder.DropPrimaryKey(
                name: "Location_PK",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "Country_PK",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "Card_PK",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "IDNumberOrPassport",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "TicketSales");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SiteType",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SiteType");

            migrationBuilder.DropColumn(
                name: "PlaceName",
                table: "PlaceRating");

            migrationBuilder.RenameTable(
                name: "SiteType",
                newName: "SiteTypes");

            migrationBuilder.RenameTable(
                name: "PlaceRating",
                newName: "PlaceRatings");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.RenameColumn(
                name: "Country_Id",
                table: "Visitors",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitors_Country_Id",
                table: "Visitors",
                newName: "IX_Visitors_CountryId");

            migrationBuilder.RenameColumn(
                name: "Visitor_Id",
                table: "TicketSales",
                newName: "VisitorId");

            migrationBuilder.RenameColumn(
                name: "Card_Id",
                table: "TicketSales",
                newName: "CardId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSales_Visitor_Id",
                table: "TicketSales",
                newName: "IX_TicketSales_VisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketSales_Card_Id",
                table: "TicketSales",
                newName: "IX_TicketSales_CardId");

            migrationBuilder.RenameColumn(
                name: "TicketSale_Id",
                table: "Tickets",
                newName: "TicketSaleId");

            migrationBuilder.RenameColumn(
                name: "Place_Id",
                table: "Tickets",
                newName: "PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketSale_Id",
                table: "Tickets",
                newName: "IX_Tickets_TicketSaleId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Place_Id",
                table: "Tickets",
                newName: "IX_Tickets_PlaceId");

            migrationBuilder.RenameColumn(
                name: "SiteType_Id",
                table: "Places",
                newName: "SiteTypeId");

            migrationBuilder.RenameColumn(
                name: "Location_Id",
                table: "Places",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_SiteType_Id",
                table: "Places",
                newName: "IX_Places_SiteTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_Location_Id",
                table: "Places",
                newName: "IX_Places_LocationId");

            migrationBuilder.RenameColumn(
                name: "Place_Id",
                table: "PlaceRatings",
                newName: "PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaceRating_Place_Id",
                table: "PlaceRatings",
                newName: "IX_PlaceRatings_PlaceId");

            migrationBuilder.AlterColumn<string>(
                name: "VisitReason",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Visitors",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "BirthCountry",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Visitors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PassportOrId",
                table: "Visitors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "TicketSales",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SaleDate",
                table: "TicketSales",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "TicketSales",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "VisitorId",
                table: "TicketSales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "TicketSales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "TicketSales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SaleDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Commission",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "TicketSaleId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Species",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesType",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "SpecialCharacteristics",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ScientificName",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Species",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommonName",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ReservedArea",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Recognitions",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Places",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Coordinates",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "SiteTypeId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "SiteTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "PlaceRatings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "PlaceRatings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Canton",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Continent",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Commission",
                table: "Cards",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visitors",
                table: "Visitors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketSales",
                table: "TicketSales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Species",
                table: "Species",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlacesXSpecies",
                table: "PlacesXSpecies",
                columns: new[] { "SpeciesId", "PlaceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiteTypes",
                table: "SiteTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaceRatings",
                table: "PlaceRatings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceRatings_Places_PlaceId",
                table: "PlaceRatings",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Locations_LocationId",
                table: "Places",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_SiteTypes_SiteTypeId",
                table: "Places",
                column: "SiteTypeId",
                principalTable: "SiteTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Places_PlaceId",
                table: "Tickets",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketSales_TicketSaleId",
                table: "Tickets",
                column: "TicketSaleId",
                principalTable: "TicketSales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketSales_Cards_CardId",
                table: "TicketSales",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketSales_Visitors_VisitorId",
                table: "TicketSales",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Countries_CountryId",
                table: "Visitors",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
