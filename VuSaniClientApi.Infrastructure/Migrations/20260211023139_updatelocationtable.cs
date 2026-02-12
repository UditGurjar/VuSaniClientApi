using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatelocationtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Organizations_OrganizationId",
                schema: "Structuralrole",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Structuralrole",
                table: "Location");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                schema: "Structuralrole",
                table: "Location",
                newName: "Parent");

            migrationBuilder.RenameIndex(
                name: "IX_Location_OrganizationId",
                schema: "Structuralrole",
                table: "Location",
                newName: "IX_Location_Parent");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Structuralrole",
                table: "Location",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "Structuralrole",
                table: "Location",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsStatic",
                schema: "Structuralrole",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                schema: "Structuralrole",
                table: "Location",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 11, 2, 31, 34, 941, DateTimeKind.Utc).AddTicks(9814), new DateTime(2026, 2, 11, 2, 31, 34, 941, DateTimeKind.Utc).AddTicks(9815) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 11, 2, 31, 34, 941, DateTimeKind.Utc).AddTicks(9818), new DateTime(2026, 2, 11, 2, 31, 34, 941, DateTimeKind.Utc).AddTicks(9819) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 11, 2, 31, 34, 941, DateTimeKind.Utc).AddTicks(9821), new DateTime(2026, 2, 11, 2, 31, 34, 941, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 11, 2, 31, 34, 941, DateTimeKind.Utc).AddTicks(9824), new DateTime(2026, 2, 11, 2, 31, 34, 941, DateTimeKind.Utc).AddTicks(9825) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 11, 2, 31, 34, 941, DateTimeKind.Utc).AddTicks(9827), new DateTime(2026, 2, 11, 2, 31, 34, 941, DateTimeKind.Utc).AddTicks(9828) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 11, 2, 31, 34, 942, DateTimeKind.Utc).AddTicks(1547), new DateTime(2026, 2, 11, 2, 31, 34, 942, DateTimeKind.Utc).AddTicks(1539), new DateTime(2026, 2, 11, 2, 31, 34, 942, DateTimeKind.Utc).AddTicks(1538), "4mZMnR/hGxDPpkQxtOCvtGfxr0r0Ei29R6oq", new DateTime(2026, 2, 11, 2, 31, 34, 942, DateTimeKind.Utc).AddTicks(1548) });

            migrationBuilder.CreateIndex(
                name: "IX_Location_DepartmentId",
                schema: "Structuralrole",
                table: "Location",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Department_DepartmentId",
                schema: "Structuralrole",
                table: "Location",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Location_Parent",
                schema: "Structuralrole",
                table: "Location",
                column: "Parent",
                principalSchema: "Structuralrole",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Department_DepartmentId",
                schema: "Structuralrole",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Location_Parent",
                schema: "Structuralrole",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_DepartmentId",
                schema: "Structuralrole",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "Structuralrole",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "IsStatic",
                schema: "Structuralrole",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Organization",
                schema: "Structuralrole",
                table: "Location");

            migrationBuilder.RenameColumn(
                name: "Parent",
                schema: "Structuralrole",
                table: "Location",
                newName: "OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_Parent",
                schema: "Structuralrole",
                table: "Location",
                newName: "IX_Location_OrganizationId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Structuralrole",
                table: "Location",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Structuralrole",
                table: "Location",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6656), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6657) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6662), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6664) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6668), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6669) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6672), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6677), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(6678) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(9530), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(9518), new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(9517), "fo8+TI7DHVbrQju2O/M+z+7WL8o8aEuRwaY=", new DateTime(2026, 2, 9, 17, 29, 49, 543, DateTimeKind.Utc).AddTicks(9532) });

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Organizations_OrganizationId",
                schema: "Structuralrole",
                table: "Location",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }
    }
}
