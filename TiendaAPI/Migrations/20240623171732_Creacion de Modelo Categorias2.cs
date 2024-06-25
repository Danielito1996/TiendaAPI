using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreaciondeModeloCategorias2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriasId",
                table: "Productos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriasId",
                table: "Productos",
                column: "CategoriasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriasId",
                table: "Productos",
                column: "CategoriasId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriasId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CategoriasId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CategoriasId",
                table: "Productos");
        }
    }
}
