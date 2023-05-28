using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class _9thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nutricionista_asigna_clientes",
                columns: table => new
                {
                    correo_cliente = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    id_nutricionista = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    cod_barras_nutri = table.Column<int>(type: "integer", nullable: false),
                    fecha_i = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_f = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutricionista_asigna_clientes", x => x.correo_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    nombre_plan = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    desayuno = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    merienda_m = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    almuerzo = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    merienda_t = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    cena = table.Column<string>(type: "varchar", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.nombre_plan);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    codigo_barra = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    grasa = table.Column<int>(type: "integer", nullable: false),
                    taman_porcion = table.Column<int>(type: "integer", nullable: false),
                    energia = table.Column<int>(type: "integer", nullable: false),
                    descripcion = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    proteina = table.Column<int>(type: "integer", nullable: false),
                    sodio = table.Column<int>(type: "integer", nullable: false),
                    hierro = table.Column<int>(type: "integer", nullable: false),
                    calcio = table.Column<int>(type: "integer", nullable: false),
                    vitaminas = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    carbohidratos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.codigo_barra);
                });

            migrationBuilder.CreateTable(
                name: "TipoCobros",
                columns: table => new
                {
                    cedula = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    cod_barras_nutri = table.Column<int>(type: "integer", nullable: false),
                    tipo_cobro = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCobros", x => x.cedula);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nutricionista_asigna_clientes");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "TipoCobros");
        }
    }
}
