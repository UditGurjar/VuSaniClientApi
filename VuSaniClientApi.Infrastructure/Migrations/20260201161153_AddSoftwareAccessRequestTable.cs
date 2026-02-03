using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftwareAccessRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema("Software");

            migrationBuilder.CreateTable(
                name: "SoftwareAccessRequest",
                schema: "Software",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UniqueId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SidebarId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department = table.Column<int>(type: "int", nullable: true),
                    Organization = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareAccessRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareAccessRequest_Department_Department",
                        column: x => x.Department,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoftwareAccessRequest_Organizations_Organization",
                        column: x => x.Organization,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoftwareAccessRequest_Sidebars_SidebarId",
                        column: x => x.SidebarId,
                        principalTable: "Sidebars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoftwareAccessRequest_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoftwareAccessRequest_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoftwareAccessRequest_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(6861), new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(6862) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(6865), new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(6866) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(6869), new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(6872), new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(6873) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(6875), new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(6876) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(8731), new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(8717), new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(8716), "olmL3RMut6uBGSR34DnoK87Hc/AqvW0RCucG", new DateTime(2026, 2, 1, 16, 11, 49, 711, DateTimeKind.Utc).AddTicks(8732) });

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareAccessRequest_CreatedBy",
                schema: "Software",
                table: "SoftwareAccessRequest",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareAccessRequest_Department",
                schema: "Software",
                table: "SoftwareAccessRequest",
                column: "Department");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareAccessRequest_Organization",
                schema: "Software",
                table: "SoftwareAccessRequest",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareAccessRequest_SidebarId",
                schema: "Software",
                table: "SoftwareAccessRequest",
                column: "SidebarId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareAccessRequest_UpdatedBy",
                schema: "Software",
                table: "SoftwareAccessRequest",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareAccessRequest_UserId",
                schema: "Software",
                table: "SoftwareAccessRequest",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoftwareAccessRequest",
                schema: "Software");

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
        }
    }
}
