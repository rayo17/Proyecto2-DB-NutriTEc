using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class _18thmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_nutricionista_asigna_clientes_Clientes_Clientecorreo",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_nutricionista_asigna_clientes_Nutricionistas_Nutricionistac~",
                table: "nutricionista_asigna_clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoCobros_Nutricionistas_Nutricionistacedula",
                table: "TipoCobros");

            migrationBuilder.DropIndex(
                name: "IX_TipoCobros_Nutricionistacedula",
                table: "TipoCobros");

            migrationBuilder.DropIndex(
                name: "IX_nutricionista_asigna_clientes_Clientecorreo",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Cobros_Nutricionistas_id_nutri",
                table: "Cobros",
                column: "id_nutri",
                principalTable: "Nutricionistas",
                principalColumn: "cedula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumos_Clientes_correo_cliente",
                table: "Consumos",
                column: "correo_cliente",
                principalTable: "Clientes",
                principalColumn: "correo",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AddColumn<string>(
                name: "Nutricionistacedula",
                table: "TipoCobros",
                type: "varchar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Clientecorreo",
                table: "nutricionista_asigna_clientes",
                type: "varchar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nutricionistacedula",
                table: "nutricionista_asigna_clientes",
                type: "varchar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Productocodigo_barra",
                table: "EstadoProductos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoCobros_Nutricionistacedula",
                table: "TipoCobros",
                column: "Nutricionistacedula");

            migrationBuilder.CreateIndex(
                name: "IX_nutricionista_asigna_clientes_Clientecorreo",
                table: "nutricionista_asigna_clientes",
                column: "Clientecorreo");

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
                name: "FK_nutricionista_asigna_clientes_Clientes_Clientecorreo",
                table: "nutricionista_asigna_clientes",
                column: "Clientecorreo",
                principalTable: "Clientes",
                principalColumn: "correo");

            migrationBuilder.AddForeignKey(
                name: "FK_nutricionista_asigna_clientes_Nutricionistas_Nutricionistac~",
                table: "nutricionista_asigna_clientes",
                column: "Nutricionistacedula",
                principalTable: "Nutricionistas",
                principalColumn: "cedula");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoCobros_Nutricionistas_Nutricionistacedula",
                table: "TipoCobros",
                column: "Nutricionistacedula",
                principalTable: "Nutricionistas",
                principalColumn: "cedula");
        }
    }
}
