using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adddepartmenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 17, 21, 22, 590, DateTimeKind.Utc).AddTicks(9684), new DateTime(2026, 1, 21, 17, 21, 22, 590, DateTimeKind.Utc).AddTicks(9685) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 17, 21, 22, 590, DateTimeKind.Utc).AddTicks(9689), new DateTime(2026, 1, 21, 17, 21, 22, 590, DateTimeKind.Utc).AddTicks(9690) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 17, 21, 22, 590, DateTimeKind.Utc).AddTicks(9694), new DateTime(2026, 1, 21, 17, 21, 22, 590, DateTimeKind.Utc).AddTicks(9694) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 17, 21, 22, 590, DateTimeKind.Utc).AddTicks(9697), new DateTime(2026, 1, 21, 17, 21, 22, 590, DateTimeKind.Utc).AddTicks(9698) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 17, 21, 22, 590, DateTimeKind.Utc).AddTicks(9701), new DateTime(2026, 1, 21, 17, 21, 22, 590, DateTimeKind.Utc).AddTicks(9702) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 17, 21, 22, 591, DateTimeKind.Utc).AddTicks(1546), new DateTime(2026, 1, 21, 17, 21, 22, 591, DateTimeKind.Utc).AddTicks(1536), new DateTime(2026, 1, 21, 17, 21, 22, 591, DateTimeKind.Utc).AddTicks(1535), "ZQojtBt53oKZJvgNPQTnSwm9bQ1d5ZtzY7AW", new DateTime(2026, 1, 21, 17, 21, 22, 591, DateTimeKind.Utc).AddTicks(1547) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 16, 37, 3, 338, DateTimeKind.Utc).AddTicks(8990), new DateTime(2026, 1, 21, 16, 37, 3, 338, DateTimeKind.Utc).AddTicks(8991) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 16, 37, 3, 338, DateTimeKind.Utc).AddTicks(8994), new DateTime(2026, 1, 21, 16, 37, 3, 338, DateTimeKind.Utc).AddTicks(8995) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 16, 37, 3, 338, DateTimeKind.Utc).AddTicks(8998), new DateTime(2026, 1, 21, 16, 37, 3, 338, DateTimeKind.Utc).AddTicks(8998) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 16, 37, 3, 338, DateTimeKind.Utc).AddTicks(9000), new DateTime(2026, 1, 21, 16, 37, 3, 338, DateTimeKind.Utc).AddTicks(9001) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 16, 37, 3, 338, DateTimeKind.Utc).AddTicks(9003), new DateTime(2026, 1, 21, 16, 37, 3, 338, DateTimeKind.Utc).AddTicks(9004) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 16, 37, 3, 339, DateTimeKind.Utc).AddTicks(661), new DateTime(2026, 1, 21, 16, 37, 3, 339, DateTimeKind.Utc).AddTicks(651), new DateTime(2026, 1, 21, 16, 37, 3, 339, DateTimeKind.Utc).AddTicks(650), "rJzuUCCH2dmaotU5l2Q2zWoYvCF55ZrpRyg=", new DateTime(2026, 1, 21, 16, 37, 3, 339, DateTimeKind.Utc).AddTicks(662) });
        }
    }
}
