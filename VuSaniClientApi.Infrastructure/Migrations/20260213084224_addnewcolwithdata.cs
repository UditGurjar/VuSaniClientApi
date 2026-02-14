using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolwithdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TerminationReason",
                schema: "Structuralrole",
                table: "HseAppointment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(5794), new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(5796) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(5799), new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(5800) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(5802), new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(5803) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(5806), new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(5806) });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(5809), new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BackgroundImage", "BusinessLogo", "FooterImage", "HeaderImage", "Name" },
                values: new object[] { "/Logo/Org1HeaderLogo.jpg", "/Logo/Org1HeaderLogo.jpg", "/Logo/Org1HeaderLogo.jpg", "/Logo/Org1HeaderLogo.jpg", "Harmony and Help Group" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "HeaderImage",
                value: "/Logo/Org2HeaderLogo.jpg");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Harmony and Help Academy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(7420), new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(7411), new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(7410), "V1BBfmW/yiVm6Agu/B7SENh5HEi00d3E", new DateTime(2026, 2, 13, 8, 42, 21, 806, DateTimeKind.Utc).AddTicks(7421) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TerminationReason",
                schema: "Structuralrole",
                table: "HseAppointment");

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
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BackgroundImage", "BusinessLogo", "FooterImage", "HeaderImage", "Name" },
                values: new object[] { "https://saapi.vusani360.africa/main_logo.png", "https://saapi.vusani360.africa/main_logo.png", "https://saapi.vusani360.africa/main_logo.png", "https://saapi.vusani360.africa/main_logo.png", "Harmony and Motors" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "HeaderImage",
                value: "https://harmonyandmotors-api.vusani360.africa/org1.png");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Harmony and Academy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "JoiningDate", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 12, 2, 3, 19, 909, DateTimeKind.Utc).AddTicks(912), new DateTime(2026, 2, 12, 2, 3, 19, 909, DateTimeKind.Utc).AddTicks(904), new DateTime(2026, 2, 12, 2, 3, 19, 909, DateTimeKind.Utc).AddTicks(903), "5kjNgaBcEys9oNe8E/J6iKp1bQy0Dk0bTg==", new DateTime(2026, 2, 12, 2, 3, 19, 909, DateTimeKind.Utc).AddTicks(913) });
        }
    }
}
