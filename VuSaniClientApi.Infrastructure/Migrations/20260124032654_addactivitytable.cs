using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addactivitytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Module = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(1796), new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(1800), new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(1801) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(1804), new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(1804) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(1807), new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(1808) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(1810), new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(1811) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(3400), new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(3392), new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(3391), "yprUQuwnZ42yCoBFQq0+YJkB2+jDWd94SQU=", new DateTime(2026, 1, 24, 3, 26, 49, 175, DateTimeKind.Utc).AddTicks(3401) });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_CreatedBy",
                table: "ActivityLogs",
                column: "CreatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

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
    }
}
