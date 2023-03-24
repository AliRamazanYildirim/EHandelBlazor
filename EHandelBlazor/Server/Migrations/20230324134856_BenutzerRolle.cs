using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHandelBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class BenutzerRolle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rolle",
                table: "Benutzer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rolle",
                table: "Benutzer");
        }
    }
}
