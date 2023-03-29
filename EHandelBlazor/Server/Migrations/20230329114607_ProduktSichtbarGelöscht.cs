using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHandelBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProduktSichtbarGelöscht : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Gelöscht",
                table: "ProduktVarianten",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sichtbar",
                table: "ProduktVarianten",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Gelöscht",
                table: "Produkte",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sichtbar",
                table: "Produkte",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ProduktVarianten",
                keyColumns: new[] { "ProduktArtID", "ProduktID" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProduktVarianten",
                keyColumns: new[] { "ProduktArtID", "ProduktID" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProduktVarianten",
                keyColumns: new[] { "ProduktArtID", "ProduktID" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProduktVarianten",
                keyColumns: new[] { "ProduktArtID", "ProduktID" },
                keyValues: new object[] { 6, 4 },
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProduktVarianten",
                keyColumns: new[] { "ProduktArtID", "ProduktID" },
                keyValues: new object[] { 6, 5 },
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProduktVarianten",
                keyColumns: new[] { "ProduktArtID", "ProduktID" },
                keyValues: new object[] { 5, 6 },
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProduktVarianten",
                keyColumns: new[] { "ProduktArtID", "ProduktID" },
                keyValues: new object[] { 9, 7 },
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProduktVarianten",
                keyColumns: new[] { "ProduktArtID", "ProduktID" },
                keyValues: new object[] { 10, 8 },
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "ProduktVarianten",
                keyColumns: new[] { "ProduktArtID", "ProduktID" },
                keyValues: new object[] { 10, 9 },
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produkte",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produkte",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produkte",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produkte",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produkte",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produkte",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produkte",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produkte",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });

            migrationBuilder.UpdateData(
                table: "Produkte",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Gelöscht", "Sichtbar" },
                values: new object[] { false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gelöscht",
                table: "ProduktVarianten");

            migrationBuilder.DropColumn(
                name: "Sichtbar",
                table: "ProduktVarianten");

            migrationBuilder.DropColumn(
                name: "Gelöscht",
                table: "Produkte");

            migrationBuilder.DropColumn(
                name: "Sichtbar",
                table: "Produkte");
        }
    }
}
