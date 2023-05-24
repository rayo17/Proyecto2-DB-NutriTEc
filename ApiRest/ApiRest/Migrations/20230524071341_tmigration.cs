using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class tmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    correo = table.Column<string>(type: "text", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    apellido1 = table.Column<string>(type: "text", nullable: false),
                    apellido2 = table.Column<string>(type: "text", nullable: false),
                    contrasena = table.Column<string>(type: "text", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    edad = table.Column<int>(type: "integer", nullable: false),
                    peso = table.Column<int>(type: "integer", nullable: false),
                    imc = table.Column<int>(type: "integer", nullable: false),
                    cintura = table.Column<int>(type: "integer", nullable: false),
                    pmuslos = table.Column<int>(type: "integer", nullable: false),
                    cuello = table.Column<int>(type: "integer", nullable: false),
                    caderas = table.Column<int>(type: "integer", nullable: false),
                    pgrasa = table.Column<int>(type: "integer", nullable: false),
                    consumo_diario_c = table.Column<int>(type: "integer", nullable: false),
                    fecha_medicion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.correo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
