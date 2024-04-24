using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModeloReporteDeVentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReporteVentasGeneralesId",
                table: "Productos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReporteVentasGeneralesId",
                table: "MateriasPrimas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReporteVentasGeneralesId1",
                table: "MateriasPrimas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReportesDeVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalPrecioDeVentas = table.Column<double>(type: "REAL", nullable: false),
                    TotalPrecioDeCosto = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportesDeVentas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ReporteVentasGeneralesId",
                table: "Productos",
                column: "ReporteVentasGeneralesId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasPrimas_ReporteVentasGeneralesId",
                table: "MateriasPrimas",
                column: "ReporteVentasGeneralesId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasPrimas_ReporteVentasGeneralesId1",
                table: "MateriasPrimas",
                column: "ReporteVentasGeneralesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasPrimas_ReportesDeVentas_ReporteVentasGeneralesId",
                table: "MateriasPrimas",
                column: "ReporteVentasGeneralesId",
                principalTable: "ReportesDeVentas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasPrimas_ReportesDeVentas_ReporteVentasGeneralesId1",
                table: "MateriasPrimas",
                column: "ReporteVentasGeneralesId1",
                principalTable: "ReportesDeVentas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_ReportesDeVentas_ReporteVentasGeneralesId",
                table: "Productos",
                column: "ReporteVentasGeneralesId",
                principalTable: "ReportesDeVentas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriasPrimas_ReportesDeVentas_ReporteVentasGeneralesId",
                table: "MateriasPrimas");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriasPrimas_ReportesDeVentas_ReporteVentasGeneralesId1",
                table: "MateriasPrimas");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_ReportesDeVentas_ReporteVentasGeneralesId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "ReportesDeVentas");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ReporteVentasGeneralesId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_MateriasPrimas_ReporteVentasGeneralesId",
                table: "MateriasPrimas");

            migrationBuilder.DropIndex(
                name: "IX_MateriasPrimas_ReporteVentasGeneralesId1",
                table: "MateriasPrimas");

            migrationBuilder.DropColumn(
                name: "ReporteVentasGeneralesId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ReporteVentasGeneralesId",
                table: "MateriasPrimas");

            migrationBuilder.DropColumn(
                name: "ReporteVentasGeneralesId1",
                table: "MateriasPrimas");
        }
    }
}
