using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedskills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "License", "Skills" },
                values: new object[] { "1", "1,2,3" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "License", "Skills" },
                values: new object[] { "2,3", "1,2,3" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "License", "Skills" },
                values: new object[] { "1,2,3", "4,5,6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(8730), new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(8724), new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(8723), "oNnnnWEiEOT3OTDQDZi5QaQPmb7f0ddBKw==", new DateTime(2026, 1, 21, 2, 32, 47, 340, DateTimeKind.Utc).AddTicks(8732) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 20, 17, 39, 48, 715, DateTimeKind.Utc).AddTicks(9908), new DateTime(2026, 1, 20, 17, 39, 48, 715, DateTimeKind.Utc).AddTicks(9909) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 20, 17, 39, 48, 715, DateTimeKind.Utc).AddTicks(9913), new DateTime(2026, 1, 20, 17, 39, 48, 715, DateTimeKind.Utc).AddTicks(9914) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 20, 17, 39, 48, 715, DateTimeKind.Utc).AddTicks(9916), new DateTime(2026, 1, 20, 17, 39, 48, 715, DateTimeKind.Utc).AddTicks(9917) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 20, 17, 39, 48, 715, DateTimeKind.Utc).AddTicks(9920), new DateTime(2026, 1, 20, 17, 39, 48, 715, DateTimeKind.Utc).AddTicks(9921) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 20, 17, 39, 48, 715, DateTimeKind.Utc).AddTicks(9923), new DateTime(2026, 1, 20, 17, 39, 48, 715, DateTimeKind.Utc).AddTicks(9924) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "License", "Skills" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "License", "Skills" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "License", "Skills" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 20, 17, 39, 48, 716, DateTimeKind.Utc).AddTicks(1441), new DateTime(2026, 1, 20, 17, 39, 48, 716, DateTimeKind.Utc).AddTicks(1434), new DateTime(2026, 1, 20, 17, 39, 48, 716, DateTimeKind.Utc).AddTicks(1433), "Ozn8cKj81ZMSuYtxeHDaNyE6SxaJXmB2gQE=", new DateTime(2026, 1, 20, 17, 39, 48, 716, DateTimeKind.Utc).AddTicks(1443) });
        }
    }
}
