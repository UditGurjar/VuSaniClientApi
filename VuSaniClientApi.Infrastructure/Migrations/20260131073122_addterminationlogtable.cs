using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addterminationlogtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TerminationNotificationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IntervalDays = table.Column<int>(type: "int", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminationNotificationLogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(3813), new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(3813) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(3817), new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(3820), new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(3821) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(3823), new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(3824) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(3826), new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(3827) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(6464), new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(6454), new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(6453), "iUyFQV2HJ7cIYbgJLD4Dh83yinXuYjdk", new DateTime(2026, 1, 31, 7, 31, 21, 914, DateTimeKind.Utc).AddTicks(6465) });

            migrationBuilder.CreateIndex(
                name: "IX_TerminationNotificationLogs_UserId_IntervalDays",
                table: "TerminationNotificationLogs",
                columns: new[] { "UserId", "IntervalDays" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerminationNotificationLogs");

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(1690), new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(1691) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(1694), new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(1694) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(1697), new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(1698) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(1700), new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(1701) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(1703), new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(1704) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(3301), new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(3292), new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(3292), "4uenXzS5z9u1mnjBcCgNdFsT0y9moMjo", new DateTime(2026, 1, 29, 9, 49, 39, 707, DateTimeKind.Utc).AddTicks(3302) });
        }
    }
}
