using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTATAutomation.Migrations
{
    /// <inheritdoc />
    public partial class intitial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weighments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TareWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EntryTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weighments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "inUseSince" },
                values: new object[] { new DateTime(2025, 2, 2, 16, 21, 43, 42, DateTimeKind.Utc).AddTicks(9560), new DateTime(2025, 2, 2, 16, 21, 43, 42, DateTimeKind.Utc).AddTicks(9560), new DateTime(2025, 2, 2, 21, 51, 43, 42, DateTimeKind.Local).AddTicks(9550) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 2, 21, 51, 43, 42, DateTimeKind.Local).AddTicks(9420), "$2a$11$V9nJhYMDZdPi3V7smCA7FO0roiR/JayoufVenCEuRzN0DrwZRRlUi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weighments");

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "inUseSince" },
                values: new object[] { new DateTime(2025, 2, 2, 15, 31, 35, 842, DateTimeKind.Utc).AddTicks(9770), new DateTime(2025, 2, 2, 15, 31, 35, 842, DateTimeKind.Utc).AddTicks(9770), new DateTime(2025, 2, 2, 21, 1, 35, 842, DateTimeKind.Local).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 2, 21, 1, 35, 842, DateTimeKind.Local).AddTicks(9660), "$2a$11$m4svH4UGcaYLbHJ8OcRq8eb6X7Y8RpepsPkxH9sGrH51Xm3Ujhvz2" });
        }
    }
}
