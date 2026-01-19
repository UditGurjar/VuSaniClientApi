using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addnewtableSidebar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sidebars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DependentModule = table.Column<int>(type: "int", nullable: true),
                    Dependency = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sidebars", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(7763), new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(7764) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(7767), new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(7768) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(7770), new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(7771) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(7773), new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(7774) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(7776), new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(7777) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(8200), new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(8201) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(8202), new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(8202) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(9989), new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(9977), new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(9977), "bwh9jOr/UmNDBq1S5eTKiZdS2fg258O83Z9O", new DateTime(2026, 1, 16, 9, 49, 17, 849, DateTimeKind.Utc).AddTicks(9990) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sidebars");

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
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(4272), new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(4262), new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(4261), "ZpEZ+Jq3B4+Am2EnpxJWcN2DJMDA2O5j", new DateTime(2026, 1, 15, 17, 24, 33, 724, DateTimeKind.Utc).AddTicks(4273) });
        }
    }
}
