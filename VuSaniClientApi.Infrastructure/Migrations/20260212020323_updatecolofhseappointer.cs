using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatecolofhseappointer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActionToken",
                schema: "Structuralrole",
                table: "HseAppointment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                schema: "Structuralrole",
                table: "HseAppointment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 12, 2, 3, 19, 908, DateTimeKind.Utc).AddTicks(8955), new DateTime(2026, 2, 12, 2, 3, 19, 908, DateTimeKind.Utc).AddTicks(8956) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 12, 2, 3, 19, 908, DateTimeKind.Utc).AddTicks(8960), new DateTime(2026, 2, 12, 2, 3, 19, 908, DateTimeKind.Utc).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 12, 2, 3, 19, 908, DateTimeKind.Utc).AddTicks(8964), new DateTime(2026, 2, 12, 2, 3, 19, 908, DateTimeKind.Utc).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 12, 2, 3, 19, 908, DateTimeKind.Utc).AddTicks(8967), new DateTime(2026, 2, 12, 2, 3, 19, 908, DateTimeKind.Utc).AddTicks(8967) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 12, 2, 3, 19, 908, DateTimeKind.Utc).AddTicks(8970), new DateTime(2026, 2, 12, 2, 3, 19, 908, DateTimeKind.Utc).AddTicks(8970) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 12, 2, 3, 19, 909, DateTimeKind.Utc).AddTicks(912), new DateTime(2026, 2, 12, 2, 3, 19, 909, DateTimeKind.Utc).AddTicks(904), new DateTime(2026, 2, 12, 2, 3, 19, 909, DateTimeKind.Utc).AddTicks(903), "5kjNgaBcEys9oNe8E/J6iKp1bQy0Dk0bTg==", new DateTime(2026, 2, 12, 2, 3, 19, 909, DateTimeKind.Utc).AddTicks(913) });

            migrationBuilder.CreateIndex(
                name: "IX_HseAppointment_ActionToken",
                schema: "Structuralrole",
                table: "HseAppointment",
                column: "ActionToken",
                unique: true,
                filter: "[ActionToken] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HseAppointment_ActionToken",
                schema: "Structuralrole",
                table: "HseAppointment");

            migrationBuilder.DropColumn(
                name: "ActionToken",
                schema: "Structuralrole",
                table: "HseAppointment");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                schema: "Structuralrole",
                table: "HseAppointment");

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
        }
    }
}
