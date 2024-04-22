using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrecciondeCamposdenavegacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriasPrimas_Inventarios_InventarioId",
                table: "MateriasPrimas");

            migrationBuilder.AlterColumn<int>(
                name: "InventarioId",
                table: "MateriasPrimas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasPrimas_Inventarios_InventarioId",
                table: "MateriasPrimas",
                column: "InventarioId",
                principalTable: "Inventarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MateriasPrimas_Inventarios_InventarioId",
                table: "MateriasPrimas");

            migrationBuilder.AlterColumn<int>(
                name: "InventarioId",
                table: "MateriasPrimas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasPrimas_Inventarios_InventarioId",
                table: "MateriasPrimas",
                column: "InventarioId",
                principalTable: "Inventarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
