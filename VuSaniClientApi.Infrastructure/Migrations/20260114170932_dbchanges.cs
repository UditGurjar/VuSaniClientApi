using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuSaniClientApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dbchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Countries",
                newName: "PhoneCode");

            migrationBuilder.AddColumn<string>(
                name: "StateCode",
                table: "States",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmojiU",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Native",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateCode",
                table: "States");

            migrationBuilder.DropColumn(
                name: "EmojiU",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Native",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "PhoneCode",
                table: "Countries",
                newName: "Code");
        }
    }
}
