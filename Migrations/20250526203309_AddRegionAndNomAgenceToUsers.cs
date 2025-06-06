using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webcardstb.Migrations
{
    /// <inheritdoc />
    public partial class AddRegionAndNomAgenceToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomAgence",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomAgence",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Users");
        }
    }
}
