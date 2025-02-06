using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTATAutomation.Migrations
{
    /// <inheritdoc />
    public partial class intitial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Weighments",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "inUseSince" },
                values: new object[] { new DateTime(2025, 2, 2, 18, 58, 48, 431, DateTimeKind.Utc).AddTicks(1780), new DateTime(2025, 2, 2, 18, 58, 48, 431, DateTimeKind.Utc).AddTicks(1780), new DateTime(2025, 2, 3, 0, 28, 48, 431, DateTimeKind.Local).AddTicks(1780) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 3, 0, 28, 48, 431, DateTimeKind.Local).AddTicks(1670), "$2a$11$zrPxkOLJ7JDydBow7s9K9uF3DfZCwA4m8j/M3lL2Gdz123sGyj0ai" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Weighments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
