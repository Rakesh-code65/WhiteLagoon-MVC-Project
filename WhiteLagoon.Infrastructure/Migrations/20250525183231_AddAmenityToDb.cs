using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAmenityToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "Name", "VillaId" },
                values: new object[,]
                {
                    { 1, "Enjoy exclusive access to a private swimming pool.", "Private Pool", 1 },
                    { 2, "Stay connected with high-speed wireless internet access.", "WiFi", 2 },
                    { 3, "Convenient in-villa microwave for quick meals and snacks.", "Microwave", 3 },
                    { 4, "Stay comfortable with modern air conditioning in every room.", "Air Conditioning", 4 },
                    { 5, "Relax in a luxurious private hot tub.", "Hot Tub", 5 },
                    { 6, "Access streaming services and cable on a large smart TV.", "Smart TV", 6 },
                    { 7, "In-unit washer and dryer for your convenience.", "Washer & Dryer", 7 },
                    { 8, "Cozy up by the fireplace on cool evenings.", "Fireplace", 8 },
                    { 9, "Enjoy beautiful views from your private balcony.", "Balcony", 9 },
                    { 10, "Outdoor BBQ grill for family cookouts.", "BBQ Grill", 10 }
                });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 101,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 102,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 103,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 201,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 202,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 301,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_VillaId",
                table: "Amenities",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 101,
                column: "SpecialDetails",
                value: "Room");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 102,
                column: "SpecialDetails",
                value: "Furnish Room");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 103,
                column: "SpecialDetails",
                value: "Semi-Furnish Room");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 201,
                column: "SpecialDetails",
                value: "Semi-Furnish Room");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 202,
                column: "SpecialDetails",
                value: "Furnish Room");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "Villa_Number",
                keyValue: 301,
                column: "SpecialDetails",
                value: "Furnish Room");
        }
    }
}
