using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class _7thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consumos",
                columns: table => new
                {
                    correo_cliente = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    desayuno = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    merienda_m = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    almuerzo = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    merienda_t = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    cena = table.Column<string>(type: "varchar", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumos", x => x.correo_cliente);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumos");
        }
    }
}
