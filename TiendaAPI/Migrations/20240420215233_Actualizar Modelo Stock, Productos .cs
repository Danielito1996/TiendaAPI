using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarModeloStockProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_CartasDeNormasTecnicas_NormasTecnicasId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Productos_ProductoId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_StocksDeIngredientes_StockDeIngredientesId",
                table: "Ingredientes");

            migrationBuilder.AlterColumn<int>(
                name: "StockDeIngredientesId",
                table: "Ingredientes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Ingredientes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "NormasTecnicasId",
                table: "Ingredientes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "CartasDeNormasTecnicas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CartasDeNormasTecnicas_ProductoId",
                table: "CartasDeNormasTecnicas",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartasDeNormasTecnicas_Productos_ProductoId",
                table: "CartasDeNormasTecnicas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_CartasDeNormasTecnicas_NormasTecnicasId",
                table: "Ingredientes",
                column: "NormasTecnicasId",
                principalTable: "CartasDeNormasTecnicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Productos_ProductoId",
                table: "Ingredientes",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_StocksDeIngredientes_StockDeIngredientesId",
                table: "Ingredientes",
                column: "StockDeIngredientesId",
                principalTable: "StocksDeIngredientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartasDeNormasTecnicas_Productos_ProductoId",
                table: "CartasDeNormasTecnicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_CartasDeNormasTecnicas_NormasTecnicasId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Productos_ProductoId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_StocksDeIngredientes_StockDeIngredientesId",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_CartasDeNormasTecnicas_ProductoId",
                table: "CartasDeNormasTecnicas");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "CartasDeNormasTecnicas");

            migrationBuilder.AlterColumn<int>(
                name: "StockDeIngredientesId",
                table: "Ingredientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Ingredientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NormasTecnicasId",
                table: "Ingredientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_CartasDeNormasTecnicas_NormasTecnicasId",
                table: "Ingredientes",
                column: "NormasTecnicasId",
                principalTable: "CartasDeNormasTecnicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Productos_ProductoId",
                table: "Ingredientes",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_StocksDeIngredientes_StockDeIngredientesId",
                table: "Ingredientes",
                column: "StockDeIngredientesId",
                principalTable: "StocksDeIngredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
