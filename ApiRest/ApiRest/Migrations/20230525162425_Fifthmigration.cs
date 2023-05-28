using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    /// <inheritdoc />
    public partial class Fifthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    id_nutri = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    cod_barras_nutri = table.Column<int>(type: "integer", nullable: false),
                    plan = table.Column<string>(type: "varchar", nullable: false),
                    monto_t = table.Column<int>(type: "integer", nullable: false),
                    descuento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.id_nutri);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobros");
        }
    }
}
