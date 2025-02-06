using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTATAutomation.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TurnArroundTime",
                table: "ParkingLogs");

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "inUseSince" },
                values: new object[] { new DateTime(2025, 2, 1, 22, 3, 54, 174, DateTimeKind.Utc).AddTicks(3440), new DateTime(2025, 2, 1, 22, 3, 54, 174, DateTimeKind.Utc).AddTicks(3440), new DateTime(2025, 2, 2, 3, 33, 54, 174, DateTimeKind.Local).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 2, 3, 33, 54, 174, DateTimeKind.Local).AddTicks(3330), "$2a$11$Vxr5ScFe.ql.Ui/3ow5ROuSD0l2EIJddlfwjf.YjRzi9BTORklHwS" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TurnArroundTime",
                table: "ParkingLogs",
                type: "datetime2",
                nullable: true);

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
    }
}
