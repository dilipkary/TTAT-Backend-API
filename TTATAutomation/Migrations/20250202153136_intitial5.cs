using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTATAutomation.Migrations
{
    /// <inheritdoc />
    public partial class intitial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GateOperations");

            migrationBuilder.CreateTable(
                name: "GateTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateTransactions", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GateTransactions");

            migrationBuilder.CreateTable(
                name: "GateOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFIDTag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateOperations", x => x.Id);
                });

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
    }
}
