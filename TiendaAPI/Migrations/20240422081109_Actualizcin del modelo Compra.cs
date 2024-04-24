using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ActualizcindelmodeloCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_MateriaPrimaAdapter_MateriaPrimaId",
                table: "Compras");

            migrationBuilder.DropTable(
                name: "MateriaPrimaAdapter");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_MateriasPrimas_MateriaPrimaId",
                table: "Compras",
                column: "MateriaPrimaId",
                principalTable: "MateriasPrimas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_MateriasPrimas_MateriaPrimaId",
                table: "Compras");

            migrationBuilder.CreateTable(
                name: "MateriaPrimaAdapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    UnidadMedida = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaPrimaAdapter", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_MateriaPrimaAdapter_MateriaPrimaId",
                table: "Compras",
                column: "MateriaPrimaId",
                principalTable: "MateriaPrimaAdapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
