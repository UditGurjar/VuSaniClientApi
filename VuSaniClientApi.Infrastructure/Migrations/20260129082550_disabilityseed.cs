using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class disabilityseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Disabilities",
                columns: new[] { "Id", "Deleted", "Description", "IsStatic", "Name", "Parent" },
                values: new object[] { 1, false, null, 1, "Physical Disabilities", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(3435), new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(3427), new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(3426), "2Zf74NYJr6ZB9qH6DKUeGuANFpcptLX/ug==", new DateTime(2026, 1, 29, 8, 25, 48, 276, DateTimeKind.Utc).AddTicks(3436) });

            migrationBuilder.InsertData(
                table: "Disabilities",
                columns: new[] { "Id", "Deleted", "Description", "IsStatic", "Name", "Parent" },
                values: new object[,]
                {
                    { 2, false, null, 1, "Mobility Impairments", 1 },
                    { 3, false, null, 1, "Amputation of limbs", 2 },
                    { 4, false, null, 1, "Paraplegia or Quadriplegia (paralysis)", 2 },
                    { 5, false, null, 1, "Muscular Dystrophy", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(2664), new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(2666) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(2670), new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(2674), new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(2674) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(2677), new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(2678) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(2681), new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(2681) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(5066), new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(5048), new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(5047), "g5I9j7OqFL/MygEKzImhp5X2ZJC8qG39", new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(5067) });
        }
    }
}
