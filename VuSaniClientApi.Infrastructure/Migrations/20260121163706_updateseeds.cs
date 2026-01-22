using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateseeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Hierarchy",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Hierarchy",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Hierarchy",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 16, 37, 3, 339, DateTimeKind.Utc).AddTicks(661), new DateTime(2026, 1, 21, 16, 37, 3, 339, DateTimeKind.Utc).AddTicks(651), new DateTime(2026, 1, 21, 16, 37, 3, 339, DateTimeKind.Utc).AddTicks(650), "rJzuUCCH2dmaotU5l2Q2zWoYvCF55ZrpRyg=", new DateTime(2026, 1, 21, 16, 37, 3, 339, DateTimeKind.Utc).AddTicks(662) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(6896), new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(6898) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(6901), new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(6902) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(6905), new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(6905) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(6908), new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(6908) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(6911), new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(6911) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Hierarchy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Hierarchy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Hierarchy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(8730), new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(8724), new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(8723), "oNnnnWEiEOT3OTDQDZi5QaQPmb7f0ddBKw==", new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(8732) });
        }
    }
}
