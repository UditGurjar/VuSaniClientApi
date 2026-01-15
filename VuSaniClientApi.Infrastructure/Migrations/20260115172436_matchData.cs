using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class matchData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2296), new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2297) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2301), new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2302) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2306), new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2307) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2310), new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2310) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2313), new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2314) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2804), new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2804) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2806), new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(2806) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "EndDate", "JoiningDate", "MyOrganization", "OrganizationAccess", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(4272), "mirriam@harmonyandmotors.com", new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(4262), new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(4261), 1, "[1,2,3]", "ZpEZ+Jq3B4+Am2EnpxJWcN2DJMDA2O5j", new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(4273) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1022), new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1023) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1026), new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1027) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1029), new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1032), new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1033) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1035), new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1446), new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1446) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1448), new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1448) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "EndDate", "JoiningDate", "MyOrganization", "OrganizationAccess", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(2611), "learn@hhacademy.africa", new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(2602), new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(2601), 204, "[205]", "BkTum+CMyO6ZLuhmGR1THWtHgOkB44hU", new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(2612) });
        }
    }
}
