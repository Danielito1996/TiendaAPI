using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Funacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriasPrimas_ReportesDeVentas_ReporteVentasGeneralesId",
                table: "MateriasPrimas");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_ReportesDeVentas_ReporteVentasGeneralesId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Ventas_VentaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ReporteVentasGeneralesId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_VentaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_MateriasPrimas_ReporteVentasGeneralesId",
                table: "MateriasPrimas");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "ReporteVentasGeneralesId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ReporteVentasGeneralesId",
                table: "MateriasPrimas");

            migrationBuilder.AddColumn<int>(
                name: "ReporteVentasGeneralesId",
                table: "ProductosVendidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "ProductosVendidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidos_ReporteVentasGeneralesId",
                table: "ProductosVendidos",
                column: "ReporteVentasGeneralesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVendidos_VentaId",
                table: "ProductosVendidos",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosVendidos_ReportesDeVentas_ReporteVentasGeneralesId",
                table: "ProductosVendidos",
                column: "ReporteVentasGeneralesId",
                principalTable: "ReportesDeVentas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosVendidos_Ventas_VentaId",
                table: "ProductosVendidos",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosVendidos_ReportesDeVentas_ReporteVentasGeneralesId",
                table: "ProductosVendidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductosVendidos_Ventas_VentaId",
                table: "ProductosVendidos");

            migrationBuilder.DropIndex(
                name: "IX_ProductosVendidos_ReporteVentasGeneralesId",
                table: "ProductosVendidos");

            migrationBuilder.DropIndex(
                name: "IX_ProductosVendidos_VentaId",
                table: "ProductosVendidos");

            migrationBuilder.DropColumn(
                name: "ReporteVentasGeneralesId",
                table: "ProductosVendidos");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "ProductosVendidos");

            migrationBuilder.AddColumn<double>(
                name: "Cantidad",
                table: "Ventas",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ReporteVentasGeneralesId",
                table: "Productos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "Productos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReporteVentasGeneralesId",
                table: "MateriasPrimas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ReporteVentasGeneralesId",
                table: "Productos",
                column: "ReporteVentasGeneralesId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_VentaId",
                table: "Productos",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasPrimas_ReporteVentasGeneralesId",
                table: "MateriasPrimas",
                column: "ReporteVentasGeneralesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasPrimas_ReportesDeVentas_ReporteVentasGeneralesId",
                table: "MateriasPrimas",
                column: "ReporteVentasGeneralesId",
                principalTable: "ReportesDeVentas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_ReportesDeVentas_ReporteVentasGeneralesId",
                table: "Productos",
                column: "ReporteVentasGeneralesId",
                principalTable: "ReportesDeVentas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Ventas_VentaId",
                table: "Productos",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id");
        }
    }
}
