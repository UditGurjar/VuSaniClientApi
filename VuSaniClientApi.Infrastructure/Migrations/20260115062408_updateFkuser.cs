using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateFkuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmploymentType",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeTypeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeTypeId",
                table: "Users",
                column: "EmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EmployeeTypes_EmployeeTypeId",
                table: "Users",
                column: "EmployeeTypeId",
                principalTable: "EmployeeTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_EmployeeTypes_EmployeeTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeeTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeTypeId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeType",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentType",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
