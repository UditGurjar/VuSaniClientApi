using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Race_RaceId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Race",
                table: "Race");

            migrationBuilder.RenameTable(
                name: "Race",
                newName: "Races");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Races",
                table: "Races",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Races_RaceId",
                table: "Users",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Races_RaceId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Races",
                table: "Races");

            migrationBuilder.RenameTable(
                name: "Races",
                newName: "Race");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Race",
                table: "Race",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(1940), new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(1941) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(1946), new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(1947) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(1949), new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(1949) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(1951), new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(1952) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(1954), new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(1955) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(3435), new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(3427), new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(3426), "2Zf74NYJr6ZB9qH6DKUeGuANFpcptLX/ug==", new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(3436) });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Race_RaceId",
                table: "Users",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "Id");
        }
    }
}
