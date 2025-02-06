using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTATAutomation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Protocol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "inUseSince" },
                values: new object[] { new DateTime(2025, 2, 6, 11, 27, 55, 400, DateTimeKind.Utc).AddTicks(6530), new DateTime(2025, 2, 6, 11, 27, 55, 400, DateTimeKind.Utc).AddTicks(6530), new DateTime(2025, 2, 6, 16, 57, 55, 400, DateTimeKind.Local).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 6, 16, 57, 55, 400, DateTimeKind.Local).AddTicks(6340), "$2a$11$s.rzl1B/nxraLARU/6.sK.p6jHKInkWhZZNTxMOyGuPUuywKPAy9u" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedAt", "LastUpdatedAt", "inUseSince" },
                values: new object[] { new DateTime(2025, 2, 6, 11, 27, 14, 740, DateTimeKind.Utc).AddTicks(930), new DateTime(2025, 2, 6, 11, 27, 14, 740, DateTimeKind.Utc).AddTicks(930), new DateTime(2025, 2, 6, 16, 57, 14, 740, DateTimeKind.Local).AddTicks(920) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 2, 6, 16, 57, 14, 740, DateTimeKind.Local).AddTicks(810), "$2a$11$2.PkFO.VdmQGTQIjbs8DpeH6SHGPFxIeanG8qtM28zugWOHxbCESO" });
        }
    }
}
