using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTATAutomation.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "inUseSince" },
                values: new object[] { new DateTime(2025, 2, 1, 20, 22, 17, 578, DateTimeKind.Utc).AddTicks(2210), new DateTime(2025, 2, 1, 20, 22, 17, 578, DateTimeKind.Utc).AddTicks(2220), new DateTime(2025, 2, 2, 1, 52, 17, 578, DateTimeKind.Local).AddTicks(2210) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 2, 1, 52, 17, 578, DateTimeKind.Local).AddTicks(2090), "$2a$11$CQ8xs/ZEHVBpQtDflPpcyezC0aApl1DHvt24CxXvCwPjTmGkFG1Yi" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Type",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Vehicles");

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "inUseSince" },
                values: new object[] { new DateTime(2025, 2, 1, 19, 53, 51, 172, DateTimeKind.Utc).AddTicks(3790), new DateTime(2025, 2, 1, 19, 53, 51, 172, DateTimeKind.Utc).AddTicks(3810), new DateTime(2025, 2, 2, 1, 23, 51, 172, DateTimeKind.Local).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 2, 1, 23, 51, 172, DateTimeKind.Local).AddTicks(3550), "$2a$11$3H00Ttc4W5P5MoBmTEMUMeWwlefzFHN.HqHP2JlN.kVN2VKutoIFa" });
        }
    }
}
