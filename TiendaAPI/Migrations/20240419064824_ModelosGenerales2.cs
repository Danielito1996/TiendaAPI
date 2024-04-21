using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModelosGenerales2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartasDeNormasTecnicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrecioDeCosto = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartasDeNormasTecnicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanesGenerales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesGenerales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductosListosParaVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosListosParaVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StocksDeIngredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksDeIngredientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    InventarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductosListosParaVentasId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Inventarios_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_ProductosListosParaVentas_ProductosListosParaVentasId",
                        column: x => x.ProductosListosParaVentasId,
                        principalTable: "ProductosListosParaVentas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Productos_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<double>(type: "REAL", nullable: false),
                    UnidadMedida = table.Column<string>(type: "TEXT", nullable: false),
                    NormasTecnicasId = table.Column<int>(type: "INTEGER", nullable: false),
                    StockDeIngredientesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredientes_CartasDeNormasTecnicas_NormasTecnicasId",
                        column: x => x.NormasTecnicasId,
                        principalTable: "CartasDeNormasTecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredientes_StocksDeIngredientes_StockDeIngredientesId",
                        column: x => x.StockDeIngredientesId,
                        principalTable: "StocksDeIngredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanesIndividuales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<double>(type: "REAL", nullable: false),
                    PlanGeneralId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesIndividuales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanesIndividuales_PlanesGenerales_PlanGeneralId",
                        column: x => x.PlanGeneralId,
                        principalTable: "PlanesGenerales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanesIndividuales_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_NormasTecnicasId",
                table: "Ingredientes",
                column: "NormasTecnicasId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_ProductoId",
                table: "Ingredientes",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_StockDeIngredientesId",
                table: "Ingredientes",
                column: "StockDeIngredientesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesIndividuales_PlanGeneralId",
                table: "PlanesIndividuales",
                column: "PlanGeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesIndividuales_ProductoId",
                table: "PlanesIndividuales",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_InventarioId",
                table: "Productos",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProductosListosParaVentasId",
                table: "Productos",
                column: "ProductosListosParaVentasId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_VentaId",
                table: "Productos",
                column: "VentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "PlanesIndividuales");

            migrationBuilder.DropTable(
                name: "CartasDeNormasTecnicas");

            migrationBuilder.DropTable(
                name: "StocksDeIngredientes");

            migrationBuilder.DropTable(
                name: "PlanesGenerales");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "ProductosListosParaVentas");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
