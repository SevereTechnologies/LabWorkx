using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Partner.GRPC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    LabId = table.Column<string>(type: "TEXT", nullable: false),
                    LabName = table.Column<string>(type: "TEXT", nullable: false),
                    LabType = table.Column<string>(type: "TEXT", nullable: false),
                    TaxCode = table.Column<int>(type: "INTEGER", nullable: false),
                    Manager = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    Zip = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Website = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.LabId);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperId = table.Column<string>(type: "TEXT", nullable: false),
                    ShipperName = table.Column<string>(type: "TEXT", nullable: false),
                    TrackingLink = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ShipperId);
                });

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "LabId", "Address", "City", "Country", "Email", "LabName", "LabType", "Manager", "Phone", "State", "TaxCode", "Website", "Zip" },
                values: new object[,]
                {
                    { "2dc061ed-0e08-472f-b8e2-607aa88f9093", "", "Phoenix", "", "", "LAB TWO", "Blood", "", "444-222-7777", "AZ", 888888, "", 85132 },
                    { "ec62634f-d4a8-46a5-a109-50387f7eb198", "", "Miami", "", "", "LAB ONE", "Specimen", "", "999-888-3333", "FL", 999999, "", 33154 }
                });

            migrationBuilder.InsertData(
                table: "Shippers",
                columns: new[] { "ShipperId", "ShipperName", "TrackingLink" },
                values: new object[,]
                {
                    { "08d0603a-3500-436d-9dd7-1b432f15ad70", "USPS", "www.usps.com/tracking/" },
                    { "6192f1a2-1976-40ee-a9c4-9b0bd74f9c7f", "UPS", "www.ups.com/tracking/" },
                    { "c00aa010-5043-47f0-bb98-fbc97f6f0654", "FedEx", "www.fedex.com/tracking/" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Labs");

            migrationBuilder.DropTable(
                name: "Shippers");
        }
    }
}
