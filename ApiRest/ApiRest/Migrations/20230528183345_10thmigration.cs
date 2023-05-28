using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class _10thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_nutricionista_asigna_clientes",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropColumn(
                name: "cod_barras_nutri",
                table: "TipoCobros");

            migrationBuilder.DropColumn(
                name: "cod_barras_nutri",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropColumn(
                name: "cod_barras_nutri",
                table: "Cobros");

            migrationBuilder.AddColumn<string>(
                name: "Nutricionistacedula",
                table: "TipoCobros",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Clientecorreo",
                table: "nutricionista_asigna_clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nutricionistacedula",
                table: "nutricionista_asigna_clientes",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "codigo_barra",
                table: "EstadoProductos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Productocodigo_barra",
                table: "EstadoProductos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_nutricionista_asigna_clientes",
                table: "nutricionista_asigna_clientes",
                columns: new[] { "id_nutricionista", "correo_cliente" });

            migrationBuilder.CreateIndex(
                name: "IX_TipoCobros_Nutricionistacedula",
                table: "TipoCobros",
                column: "Nutricionistacedula");

            migrationBuilder.CreateIndex(
                name: "IX_nutricionista_asigna_clientes_Clientecorreo",
                table: "nutricionista_asigna_clientes",
                column: "Clientecorreo");

            migrationBuilder.CreateIndex(
                name: "IX_nutricionista_asigna_clientes_correo_cliente",
                table: "nutricionista_asigna_clientes",
                column: "correo_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_nutricionista_asigna_clientes_Nutricionistacedula",
                table: "nutricionista_asigna_clientes",
                column: "Nutricionistacedula");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoProductos_Productocodigo_barra",
                table: "EstadoProductos",
                column: "Productocodigo_barra");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobros_Nutricionistas_id_nutri",
                table: "Cobros",
                column: "id_nutri",
                principalTable: "Nutricionistas",
                principalColumn: "cedula",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumos_Clientes_correo_cliente",
                table: "Consumos",
                column: "correo_cliente",
                principalTable: "Clientes",
                principalColumn: "correo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoProductos_Productos_Productocodigo_barra",
                table: "EstadoProductos",
                column: "Productocodigo_barra",
                principalTable: "Productos",
                principalColumn: "codigo_barra");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoProductos_Productos_codigo_barra",
                table: "EstadoProductos",
                column: "codigo_barra",
                principalTable: "Productos",
                principalColumn: "codigo_barra",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_nutricionista_asigna_clientes_Clientes_Clientecorreo",
                table: "nutricionista_asigna_clientes",
                column: "Clientecorreo",
                principalTable: "Clientes",
                principalColumn: "correo");

            migrationBuilder.AddForeignKey(
                name: "FK_nutricionista_asigna_clientes_Clientes_correo_cliente",
                table: "nutricionista_asigna_clientes",
                column: "correo_cliente",
                principalTable: "Clientes",
                principalColumn: "correo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_nutricionista_asigna_clientes_Nutricionistas_Nutricionistac~",
                table: "nutricionista_asigna_clientes",
                column: "Nutricionistacedula",
                principalTable: "Nutricionistas",
                principalColumn: "cedula");

            migrationBuilder.AddForeignKey(
                name: "FK_nutricionista_asigna_clientes_Nutricionistas_id_nutricionis~",
                table: "nutricionista_asigna_clientes",
                column: "id_nutricionista",
                principalTable: "Nutricionistas",
                principalColumn: "cedula",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoCobros_Nutricionistas_Nutricionistacedula",
                table: "TipoCobros",
                column: "Nutricionistacedula",
                principalTable: "Nutricionistas",
                principalColumn: "cedula");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoCobros_Nutricionistas_cedula",
                table: "TipoCobros",
                column: "cedula",
                principalTable: "Nutricionistas",
                principalColumn: "cedula",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobros_Nutricionistas_id_nutri",
                table: "Cobros");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumos_Clientes_correo_cliente",
                table: "Consumos");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadoProductos_Productos_Productocodigo_barra",
                table: "EstadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadoProductos_Productos_codigo_barra",
                table: "EstadoProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_nutricionista_asigna_clientes_Clientes_Clientecorreo",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_nutricionista_asigna_clientes_Clientes_correo_cliente",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_nutricionista_asigna_clientes_Nutricionistas_Nutricionistac~",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_nutricionista_asigna_clientes_Nutricionistas_id_nutricionis~",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoCobros_Nutricionistas_Nutricionistacedula",
                table: "TipoCobros");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoCobros_Nutricionistas_cedula",
                table: "TipoCobros");

            migrationBuilder.DropIndex(
                name: "IX_TipoCobros_Nutricionistacedula",
                table: "TipoCobros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_nutricionista_asigna_clientes",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropIndex(
                name: "IX_nutricionista_asigna_clientes_Clientecorreo",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropIndex(
                name: "IX_nutricionista_asigna_clientes_correo_cliente",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropIndex(
                name: "IX_nutricionista_asigna_clientes_Nutricionistacedula",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropIndex(
                name: "IX_EstadoProductos_Productocodigo_barra",
                table: "EstadoProductos");

            migrationBuilder.DropColumn(
                name: "Nutricionistacedula",
                table: "TipoCobros");

            migrationBuilder.DropColumn(
                name: "Clientecorreo",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropColumn(
                name: "Nutricionistacedula",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropColumn(
                name: "Productocodigo_barra",
                table: "EstadoProductos");

            migrationBuilder.AddColumn<int>(
                name: "cod_barras_nutri",
                table: "TipoCobros",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cod_barras_nutri",
                table: "nutricionista_asigna_clientes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "codigo_barra",
                table: "EstadoProductos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "cod_barras_nutri",
                table: "Cobros",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_nutricionista_asigna_clientes",
                table: "nutricionista_asigna_clientes",
                column: "correo_cliente");
        }
    }
}
