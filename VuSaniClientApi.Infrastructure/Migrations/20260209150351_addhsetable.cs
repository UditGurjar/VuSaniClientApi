using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addhsetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Structuralrole");

            migrationBuilder.CreateTable(
                name: "AppointmentType",
                schema: "Structuralrole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Assignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Applicable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentType_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentType_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Structuralrole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HseAppointment",
                schema: "Structuralrole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AppointsUserId = table.Column<int>(type: "int", nullable: true),
                    AppointedUserId = table.Column<int>(type: "int", nullable: true),
                    NameOfAppointment = table.Column<int>(type: "int", nullable: true),
                    LegalAppointmentRole = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhysicalLocation = table.Column<int>(type: "int", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AppointerDdrmId = table.Column<int>(type: "int", nullable: true),
                    AppointedDdrmId = table.Column<int>(type: "int", nullable: true),
                    DdrmId = table.Column<int>(type: "int", nullable: true),
                    AgreementId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AgreementStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LibraryDocumentId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HseAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HseAppointment_AppointmentType_NameOfAppointment",
                        column: x => x.NameOfAppointment,
                        principalSchema: "Structuralrole",
                        principalTable: "AppointmentType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HseAppointment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HseAppointment_Location_PhysicalLocation",
                        column: x => x.PhysicalLocation,
                        principalSchema: "Structuralrole",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HseAppointment_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HseAppointment_Users_AppointedUserId",
                        column: x => x.AppointedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HseAppointment_Users_AppointsUserId",
                        column: x => x.AppointsUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HseAppointment_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HseAppointment_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2249), new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2250) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2253), new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2254) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2257), new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2257) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2260), new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2261) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2263), new DateTime(2026, 2, 9, 15, 3, 46, 950, DateTimeKind.Utc).AddTicks(2264) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 15, 3, 46, 955, DateTimeKind.Utc).AddTicks(4093), new DateTime(2026, 2, 9, 15, 3, 46, 955, DateTimeKind.Utc).AddTicks(4083), new DateTime(2026, 2, 9, 15, 3, 46, 955, DateTimeKind.Utc).AddTicks(4082), "6k9kxq0qaXl7JMSefY5nWtrxKOmuCPrO", new DateTime(2026, 2, 9, 15, 3, 46, 955, DateTimeKind.Utc).AddTicks(4094) });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentType_CreatedBy",
                schema: "Structuralrole",
                table: "AppointmentType",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentType_UpdatedBy",
                schema: "Structuralrole",
                table: "AppointmentType",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HseAppointment_AppointedUserId",
                schema: "Structuralrole",
                table: "HseAppointment",
                column: "AppointedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HseAppointment_AppointsUserId",
                schema: "Structuralrole",
                table: "HseAppointment",
                column: "AppointsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HseAppointment_CreatedBy",
                schema: "Structuralrole",
                table: "HseAppointment",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HseAppointment_DepartmentId",
                schema: "Structuralrole",
                table: "HseAppointment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HseAppointment_NameOfAppointment",
                schema: "Structuralrole",
                table: "HseAppointment",
                column: "NameOfAppointment");

            migrationBuilder.CreateIndex(
                name: "IX_HseAppointment_OrganizationId",
                schema: "Structuralrole",
                table: "HseAppointment",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_HseAppointment_PhysicalLocation",
                schema: "Structuralrole",
                table: "HseAppointment",
                column: "PhysicalLocation");

            migrationBuilder.CreateIndex(
                name: "IX_HseAppointment_UpdatedBy",
                schema: "Structuralrole",
                table: "HseAppointment",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CreatedBy",
                schema: "Structuralrole",
                table: "Location",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Location_OrganizationId",
                schema: "Structuralrole",
                table: "Location",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_UpdatedBy",
                schema: "Structuralrole",
                table: "Location",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HseAppointment",
                schema: "Structuralrole");

            migrationBuilder.DropTable(
                name: "AppointmentType",
                schema: "Structuralrole");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Structuralrole");

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
        }
    }
}
