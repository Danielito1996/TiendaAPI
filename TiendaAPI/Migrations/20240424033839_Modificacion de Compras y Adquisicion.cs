using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModificaciondeComprasyAdquisicion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_MateriasPrimas_MateriaPrimaId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_MateriaPrimaId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "MateriaPrimaId",
                table: "Compras");

            migrationBuilder.AddColumn<double>(
                name: "Cantidad",
                table: "Compras",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MateriaPrima",
                table: "Compras",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnidadDeMedida",
                table: "Compras",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "MontoTotal",
                table: "Adquisiciones",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "MateriaPrima",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "UnidadDeMedida",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "MontoTotal",
                table: "Adquisiciones");

            migrationBuilder.AddColumn<int>(
                name: "MateriaPrimaId",
                table: "Compras",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_MateriaPrimaId",
                table: "Compras",
                column: "MateriaPrimaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_MateriasPrimas_MateriaPrimaId",
                table: "Compras",
                column: "MateriaPrimaId",
                principalTable: "MateriasPrimas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
