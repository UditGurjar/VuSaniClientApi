    using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedeletedcol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Skills",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Roles",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "RoleHierarchies",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Organizations",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Licences",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "HighestQualifications",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 7,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 8,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 9,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 10,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 11,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 12,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deleted", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1446), false, new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1446) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deleted", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1448), false, new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(1448) });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                column: "Deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deleted", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(2611), false, new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(2602), new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(2601), "BkTum+CMyO6ZLuhmGR1THWtHgOkB44hU", new DateTime(2026, 1, 15, 9, 48, 48, 90, DateTimeKind.Utc).AddTicks(2612) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Deleted",
                table: "Users",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Deleted",
                table: "Skills",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Deleted",
                table: "Roles",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Deleted",
                table: "RoleHierarchies",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Deleted",
                table: "Organizations",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Deleted",
                table: "Licences",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Deleted",
                table: "HighestQualifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1983), new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1985) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1989), new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1991) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1995), new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(1996) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(2000), new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(2001) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(2004), new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(2005) });

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 7,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 8,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 9,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 10,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 11,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "HighestQualifications",
                keyColumn: "Id",
                keyValue: 12,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Licences",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoleHierarchies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deleted", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(3676), null, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(3676) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deleted", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(3679), null, new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12,
                column: "Deleted",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deleted", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(6656), "0", new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(6645), new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(6644), "tyBqCuMQrmJboukQM66P+Rofl08DUeGP0wXw", new DateTime(2026, 1, 15, 6, 50, 29, 203, DateTimeKind.Utc).AddTicks(6658) });
        }
    }
}
