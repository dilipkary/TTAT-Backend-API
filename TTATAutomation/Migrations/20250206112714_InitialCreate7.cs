using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTATAutomation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

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
    }
}
