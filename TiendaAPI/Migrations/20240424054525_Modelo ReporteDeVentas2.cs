using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModeloReporteDeVentas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriasPrimas_ReportesDeVentas_ReporteVentasGeneralesId1",
                table: "MateriasPrimas");

            migrationBuilder.DropIndex(
                name: "IX_MateriasPrimas_ReporteVentasGeneralesId1",
                table: "MateriasPrimas");

            migrationBuilder.DropColumn(
                name: "ReporteVentasGeneralesId1",
                table: "MateriasPrimas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReporteVentasGeneralesId1",
                table: "MateriasPrimas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MateriasPrimas_ReporteVentasGeneralesId1",
                table: "MateriasPrimas",
                column: "ReporteVentasGeneralesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasPrimas_ReportesDeVentas_ReporteVentasGeneralesId1",
                table: "MateriasPrimas",
                column: "ReporteVentasGeneralesId1",
                principalTable: "ReportesDeVentas",
                principalColumn: "Id");
        }
    }
}
