using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newcolchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_NextOfKins_NextOfKinId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_NextOfKinId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeContactDetails",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NextOfKinId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeContactDetails",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_NextOfKinId",
                table: "Users",
                column: "NextOfKinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_NextOfKins_NextOfKinId",
                table: "Users",
                column: "NextOfKinId",
                principalTable: "NextOfKins",
                principalColumn: "NextOfKinId");
        }
    }
}
