using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHandelBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class KategorieModell : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Gelöscht",
                table: "Kategorien",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sichtbar",
                table: "Kategorien",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Kategorien",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Kategorien",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Kategorien",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gelöscht",
                table: "Kategorien");

            migrationBuilder.DropColumn(
                name: "Sichtbar",
                table: "Kategorien");
        }
    }
}
