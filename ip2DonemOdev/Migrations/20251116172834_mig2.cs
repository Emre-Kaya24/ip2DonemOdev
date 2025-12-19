using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ip2DonemOdev.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Climate",
                table: "Countries",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocalLanguages",
                table: "Countries",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Countries",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficialLanguage",
                table: "Countries",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Population",
                table: "Countries",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Climate",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LocalLanguages",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "OfficialLanguage",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Countries");
        }
    }
}
