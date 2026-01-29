using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inactiveseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReasonForInactives_Department_DepartmentId",
                table: "ReasonForInactives");

            migrationBuilder.DropForeignKey(
                name: "FK_ReasonForInactives_Organizations_OrganizationId",
                table: "ReasonForInactives");

            migrationBuilder.DropIndex(
                name: "IX_ReasonForInactives_DepartmentId",
                table: "ReasonForInactives");

            migrationBuilder.DropIndex(
                name: "IX_ReasonForInactives_OrganizationId",
                table: "ReasonForInactives");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ReasonForInactives");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ReasonForInactives");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "ReasonForInactives");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "ReasonForInactives");

            migrationBuilder.DropColumn(
                name: "UniqueId",
                table: "ReasonForInactives");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ReasonForInactives");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ReasonForInactives");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "ReasonForInactives",
                type: "bit",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

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

            migrationBuilder.InsertData(
                table: "ReasonForInactives",
                columns: new[] { "Id", "Deleted", "Description", "Name" },
                values: new object[,]
                {
                    { 1, false, "Refers to an employee whose employment has been terminated by the employer due to operational or economic reasons, rather than personal misconduct or poor performance.", "Retrenched" },
                    { 2, false, "Refers to a person who has permanently withdrawn from active employment or professional work, usually after reaching a certain age or completing the required years of service.", "Retired" },
                    { 3, false, "Refers to the conclusion of an employment, service, or business agreement once the agreed-upon period, conditions, or obligations have been fulfilled.", "End Of Contract" },
                    { 4, false, "Refers to a person who has died.", "Deceased" },
                    { 5, false, "A termination of an employee’s contract of employment by the employer, usually due to misconduct, poor performance, redundancy, or violation of company policies.", "Dismissal" },
                    { 6, false, "A formal act of voluntarily leaving a job, position, or office by an employee or officeholder.", "Resignation" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(5066), new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(5048), new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(5047), "g5I9j7OqFL/MygEKzImhp5X2ZJC8qG39", new DateTime(2026, 1, 29, 6, 58, 25, 876, DateTimeKind.Utc).AddTicks(5067) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReasonForInactives",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReasonForInactives",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReasonForInactives",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReasonForInactives",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReasonForInactives",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReasonForInactives",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Deleted",
                table: "ReasonForInactives",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ReasonForInactives",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ReasonForInactives",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "ReasonForInactives",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "ReasonForInactives",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueId",
                table: "ReasonForInactives",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ReasonForInactives",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "ReasonForInactives",
                type: "int",
                nullable: true);

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
                name: "IX_ReasonForInactives_DepartmentId",
                table: "ReasonForInactives",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonForInactives_OrganizationId",
                table: "ReasonForInactives",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReasonForInactives_Department_DepartmentId",
                table: "ReasonForInactives",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReasonForInactives_Organizations_OrganizationId",
                table: "ReasonForInactives",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }
    }
}
