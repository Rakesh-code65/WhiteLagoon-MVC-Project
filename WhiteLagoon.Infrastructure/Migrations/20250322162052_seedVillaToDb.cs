using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedVillaToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Created_Date", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "Updated_Date" },
                values: new object[,]
                {
                    { 1, null, "A luxurious villa with a stunning ocean view and private beach access.", "https://example.com/images/ocean-view-villa.jpg", "Ocean View Villa", 6, 250.0, 3500, null },
                    { 2, null, "A peaceful retreat nestled in the mountains, perfect for relaxation.", "https://example.com/images/mountain-retreat.jpg", "Mountain Retreat", 4, 180.0, 2800, null },
                    { 3, null, "A beautiful villa surrounded by lush tropical gardens.", "https://example.com/images/tropical-paradise.jpg", "Tropical Paradise", 8, 320.0, 4200, null },
                    { 4, null, "An elegant mansion with breathtaking lake views and modern amenities.", "https://example.com/images/lakeview-mansion.jpg", "Lakeview Mansion", 10, 500.0, 5500, null },
                    { 5, null, "A unique villa in the heart of the desert, featuring a private pool and spa.", "https://example.com/images/desert-oasis.jpg", "Desert Oasis", 5, 220.0, 3000, null },
                    { 6, null, "A secluded villa in the woods, offering tranquility and nature views.", "https://example.com/images/forest-hideaway.jpg", "Forest Hideaway", 6, 260.0, 3300, null },
                    { 7, null, "A modern villa with direct beach access and a private infinity pool.", "https://example.com/images/seaside-escape.jpg", "Seaside Escape", 7, 400.0, 5000, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
