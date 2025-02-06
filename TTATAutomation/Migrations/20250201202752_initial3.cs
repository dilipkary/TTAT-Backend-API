using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTATAutomation.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permit",
                table: "ParkingSlots");

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "inUseSince" },
                values: new object[] { new DateTime(2025, 2, 1, 20, 27, 52, 346, DateTimeKind.Utc).AddTicks(6180), new DateTime(2025, 2, 1, 20, 27, 52, 346, DateTimeKind.Utc).AddTicks(6180), new DateTime(2025, 2, 2, 1, 57, 52, 346, DateTimeKind.Local).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 2, 1, 57, 52, 346, DateTimeKind.Local).AddTicks(6080), "$2a$11$hSO56tHqHBe2RJhw.sNkQeNcvT.EaWFXtVnEy4M81M0tSlXrfji2e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Permit",
                table: "ParkingSlots",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "Permit", "inUseSince" },
                values: new object[] { new DateTime(2025, 2, 1, 20, 22, 17, 578, DateTimeKind.Utc).AddTicks(2210), new DateTime(2025, 2, 1, 20, 22, 17, 578, DateTimeKind.Utc).AddTicks(2220), new DateOnly(2026, 2, 1), new DateTime(2025, 2, 2, 1, 52, 17, 578, DateTimeKind.Local).AddTicks(2210) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 2, 1, 52, 17, 578, DateTimeKind.Local).AddTicks(2090), "$2a$11$CQ8xs/ZEHVBpQtDflPpcyezC0aApl1DHvt24CxXvCwPjTmGkFG1Yi" });
        }
    }
}
