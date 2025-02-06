using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTATAutomation.Migrations
{
    /// <inheritdoc />
    public partial class intitial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductType",
                table: "Weighments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DriverName",
                table: "Weighments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "Weighments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Weighments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "inUseSince" },
                values: new object[] { new DateTime(2025, 2, 2, 17, 3, 6, 966, DateTimeKind.Utc).AddTicks(3910), new DateTime(2025, 2, 2, 17, 3, 6, 966, DateTimeKind.Utc).AddTicks(3910), new DateTime(2025, 2, 2, 22, 33, 6, 966, DateTimeKind.Local).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 2, 22, 33, 6, 966, DateTimeKind.Local).AddTicks(3800), "$2a$11$eiGGm/akc41wU7WnOPrbY.Ot1jKDPMQQ0QOGoCvTvLKgkERrUifAu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductType",
                table: "Weighments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DriverName",
                table: "Weighments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "Weighments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Weighments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
