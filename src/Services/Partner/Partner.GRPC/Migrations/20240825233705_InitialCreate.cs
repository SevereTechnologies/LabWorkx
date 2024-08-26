using System;
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
                    LabId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    ShipperId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    { new Guid("03755f35-35b6-4674-8f3d-9d69eb3acad6"), "", "Miami", "", "", "LAB ONE", "Specimen", "", "999-888-3333", "FL", 999999, "", 33154 },
                    { new Guid("aabcad5d-c2ad-4502-b71b-b6ec0e5bcf85"), "", "Phoenix", "", "", "LAB TWO", "Blood", "", "444-222-7777", "AZ", 888888, "", 85132 }
                });

            migrationBuilder.InsertData(
                table: "Shippers",
                columns: new[] { "ShipperId", "ShipperName", "TrackingLink" },
                values: new object[,]
                {
                    { new Guid("27a1c178-2b83-42b8-86d8-5b1659848ecd"), "UPS", "www.ups.com/tracking/" },
                    { new Guid("32aa8e59-0d18-4292-beac-a56edfecb170"), "USPS", "www.usps.com/tracking/" },
                    { new Guid("3eb4adf2-df2a-499c-8010-e980f8b71d97"), "FedEx", "www.fedex.com/tracking/" }
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
