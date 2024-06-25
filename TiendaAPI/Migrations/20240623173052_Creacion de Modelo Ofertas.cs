using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreaciondeModeloOfertas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfertasId",
                table: "Categorias",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_OfertasId",
                table: "Categorias",
                column: "OfertasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Ofertas_OfertasId",
                table: "Categorias",
                column: "OfertasId",
                principalTable: "Ofertas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Ofertas_OfertasId",
                table: "Categorias");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_OfertasId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "OfertasId",
                table: "Categorias");
        }
    }
}
