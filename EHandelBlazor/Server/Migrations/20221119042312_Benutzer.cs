using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHandelBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class Benutzer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benutzer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswortHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswortSalz = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DatumErstellt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benutzer", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Benutzer");
        }
    }
}
