using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APIWEBAPP.Migrations
{
    /// <inheritdoc />
    public partial class _1ermitration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CorreoElectronico = table.Column<string>(type: "varchar", maxLength: 320, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    Apellido1 = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    Apellido2 = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    Edad = table.Column<int>(type: "integer", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Peso = table.Column<int>(type: "integer", nullable: false),
                    IMC = table.Column<int>(type: "integer", nullable: false),
                    PaisResidencia = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    PesoActual = table.Column<int>(type: "integer", nullable: false),
                    Cintura = table.Column<int>(type: "integer", nullable: false),
                    PorcentajeMusculos = table.Column<int>(type: "integer", nullable: false),
                    Cuello = table.Column<int>(type: "integer", nullable: false),
                    Caderas = table.Column<int>(type: "integer", nullable: false),
                    PorcentajeGrasa = table.Column<int>(type: "integer", nullable: false),
                    ConsumoDiarioCalorias = table.Column<int>(type: "integer", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    CodigoBarra = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    nombre = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    taman_porcion = table.Column<int>(type: "integer", nullable: false),
                    energia = table.Column<int>(type: "integer", nullable: false),
                    grasa = table.Column<int>(type: "integer", nullable: false),
                    sodio = table.Column<int>(type: "integer", nullable: false),
                    carbohidratos = table.Column<int>(type: "integer", nullable: false),
                    proteina = table.Column<int>(type: "integer", nullable: false),
                    vitaminas = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    calcio = table.Column<int>(type: "integer", nullable: false),
                    hierro = table.Column<int>(type: "integer", nullable: false),
                    descripcion = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    EstadoProducto = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.CodigoBarra);
                });

            migrationBuilder.CreateTable(
                name: "TipoCobros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreTipoCobro = table.Column<string>(type: "varchar", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCobros", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteID = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido1 = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    Apellido2 = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    Edad = table.Column<int>(type: "integer", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Peso = table.Column<int>(type: "integer", nullable: false),
                    IMC = table.Column<int>(type: "integer", nullable: false),
                    PaisResidencia = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    PesoActual = table.Column<int>(type: "integer", nullable: false),
                    Cintura = table.Column<int>(type: "integer", nullable: false),
                    PorcentajeMusculos = table.Column<int>(type: "integer", nullable: false),
                    Cuello = table.Column<int>(type: "integer", nullable: false),
                    Caderas = table.Column<int>(type: "integer", nullable: false),
                    PorcentajeGrasa = table.Column<int>(type: "integer", nullable: false),
                    ConsumoDiarioCalorias = table.Column<int>(type: "integer", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pacientes_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadoProductos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductoID = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    FechaAprobacion = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoProductos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EstadoProductos_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "CodigoBarra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    CaloriasTotalesReceta = table.Column<int>(type: "integer", nullable: false),
                    ProductoID = table.Column<string>(type: "varchar", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recetas_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "CodigoBarra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nutricionistas",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "varchar", maxLength: 12, nullable: false),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    Apellido1 = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    Apellido2 = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    CododigoBarras = table.Column<string>(type: "varchar", maxLength: 127, nullable: false),
                    Edad = table.Column<int>(type: "integer", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Peso = table.Column<int>(type: "integer", nullable: false),
                    IMC = table.Column<int>(type: "integer", nullable: false),
                    Direccion = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    Foto = table.Column<byte[]>(type: "bytea", nullable: true),
                    NumTarjetaCredito = table.Column<string>(type: "varchar", maxLength: 16, nullable: false),
                    TipoCobroID = table.Column<int>(type: "integer", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "varchar", maxLength: 320, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutricionistas", x => x.Cedula);
                    table.ForeignKey(
                        name: "FK_Nutricionistas_TipoCobros_TipoCobroID",
                        column: x => x.TipoCobroID,
                        principalTable: "TipoCobros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanesAlimentacion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombrePlan = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    NutricionistaID = table.Column<string>(type: "varchar", maxLength: 12, nullable: false),
                    CaloriasTotalPlan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesAlimentacion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlanesAlimentacion_Nutricionistas_NutricionistaID",
                        column: x => x.NutricionistaID,
                        principalTable: "Nutricionistas",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportesCobro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NutricionistaID = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    TipoCobroID = table.Column<int>(type: "integer", nullable: false),
                    MontoTotal = table.Column<int>(type: "integer", nullable: false),
                    Descuento = table.Column<int>(type: "integer", nullable: false),
                    MontoCobrar = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportesCobro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReportesCobro_Nutricionistas_NutricionistaID",
                        column: x => x.NutricionistaID,
                        principalTable: "Nutricionistas",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportesCobro_TipoCobros_TipoCobroID",
                        column: x => x.TipoCobroID,
                        principalTable: "TipoCobros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retroalimentaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NutricionistaID = table.Column<string>(type: "varchar", maxLength: 12, nullable: false),
                    ClienteID = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comentario = table.Column<string>(type: "varchar", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retroalimentaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Retroalimentaciones_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retroalimentaciones_Nutricionistas_NutricionistaID",
                        column: x => x.NutricionistaID,
                        principalTable: "Nutricionistas",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiempoComidas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    PlanAlimentacionID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiempoComidas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TiempoComidas_PlanesAlimentacion_PlanAlimentacionID",
                        column: x => x.PlanAlimentacionID,
                        principalTable: "PlanesAlimentacion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosPlan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductoID = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    TiempoComidaID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosPlan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductosPlan_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "CodigoBarra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosPlan_TiempoComidas_TiempoComidaID",
                        column: x => x.TiempoComidaID,
                        principalTable: "TiempoComidas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosDiarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteID = table.Column<int>(type: "integer", nullable: false),
                    TiempoComidaID = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CantidadComsumida = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosDiarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegistrosDiarios_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistrosDiarios_TiempoComidas_TiempoComidaID",
                        column: x => x.TiempoComidaID,
                        principalTable: "TiempoComidas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstadoProductos_ProductoID",
                table: "EstadoProductos",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Nutricionistas_TipoCobroID",
                table: "Nutricionistas",
                column: "TipoCobroID");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ClienteID",
                table: "Pacientes",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesAlimentacion_NutricionistaID",
                table: "PlanesAlimentacion",
                column: "NutricionistaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosPlan_ProductoID",
                table: "ProductosPlan",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosPlan_TiempoComidaID",
                table: "ProductosPlan",
                column: "TiempoComidaID");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_ProductoID",
                table: "Recetas",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosDiarios_ClienteID",
                table: "RegistrosDiarios",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosDiarios_TiempoComidaID",
                table: "RegistrosDiarios",
                column: "TiempoComidaID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesCobro_NutricionistaID",
                table: "ReportesCobro",
                column: "NutricionistaID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesCobro_TipoCobroID",
                table: "ReportesCobro",
                column: "TipoCobroID");

            migrationBuilder.CreateIndex(
                name: "IX_Retroalimentaciones_ClienteID",
                table: "Retroalimentaciones",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Retroalimentaciones_NutricionistaID",
                table: "Retroalimentaciones",
                column: "NutricionistaID");

            migrationBuilder.CreateIndex(
                name: "IX_TiempoComidas_PlanAlimentacionID",
                table: "TiempoComidas",
                column: "PlanAlimentacionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "EstadoProductos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "ProductosPlan");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "RegistrosDiarios");

            migrationBuilder.DropTable(
                name: "ReportesCobro");

            migrationBuilder.DropTable(
                name: "Retroalimentaciones");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "TiempoComidas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "PlanesAlimentacion");

            migrationBuilder.DropTable(
                name: "Nutricionistas");

            migrationBuilder.DropTable(
                name: "TipoCobros");
        }
    }
}
