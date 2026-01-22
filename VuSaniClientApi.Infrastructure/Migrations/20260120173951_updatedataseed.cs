using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Qualification",
                table: "Roles",
                newName: "QualificationId");

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
                columns: new[] { "QualificationId", "ReportToRole", "YearOfExperience" },
                values: new object[] { 8, "3", "1-2" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "QualificationId", "ReportToRole", "UpdatedAt", "YearOfExperience" },
                values: new object[] { new DateTime(2025, 8, 11, 10, 23, 3, 0, DateTimeKind.Unspecified), 1, 5, "3", new DateTime(2025, 8, 11, 10, 23, 3, 0, DateTimeKind.Unspecified), "5-6" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "QualificationId", "UpdatedAt", "YearOfExperience" },
                values: new object[] { new DateTime(2025, 8, 11, 10, 23, 3, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2025, 8, 11, 10, 23, 3, 0, DateTimeKind.Unspecified), "5-6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 20, 17, 39, 48, 716, DateTimeKind.Utc).AddTicks(1441), new DateTime(2026, 1, 20, 17, 39, 48, 716, DateTimeKind.Utc).AddTicks(1434), new DateTime(2026, 1, 20, 17, 39, 48, 716, DateTimeKind.Utc).AddTicks(1433), "Ozn8cKj81ZMSuYtxeHDaNyE6SxaJXmB2gQE=", new DateTime(2026, 1, 20, 17, 39, 48, 716, DateTimeKind.Utc).AddTicks(1443) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QualificationId",
                table: "Roles",
                newName: "Qualification");

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2386), new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2387) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2390), new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2391) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2394), new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2395) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2397), new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2398) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2400), new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2401) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Qualification", "ReportToRole", "YearOfExperience" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "Qualification", "ReportToRole", "UpdatedAt", "YearOfExperience" },
                values: new object[] { new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2816), null, null, null, new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2816), null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Qualification", "UpdatedAt", "YearOfExperience" },
                values: new object[] { new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2818), null, null, new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(2818), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(3999), new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(3989), new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(3989), "orbhUOsgS6uS/pPKeLiTYE5ECuiZyXpPVbo=", new DateTime(2026, 1, 16, 10, 20, 27, 164, DateTimeKind.Utc).AddTicks(4000) });
        }
    }
}
