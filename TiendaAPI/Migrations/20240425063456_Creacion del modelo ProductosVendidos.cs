using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreaciondelmodeloProductosVendidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductosVendidosid",
                table: "Productos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PRoductosVendidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRoductosVendidos", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProductosVendidosid",
                table: "Productos",
                column: "ProductosVendidosid");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_PRoductosVendidos_ProductosVendidosid",
                table: "Productos",
                column: "ProductosVendidosid",
                principalTable: "PRoductosVendidos",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_PRoductosVendidos_ProductosVendidosid",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "PRoductosVendidos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ProductosVendidosid",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProductosVendidosid",
                table: "Productos");
        }
    }
}
