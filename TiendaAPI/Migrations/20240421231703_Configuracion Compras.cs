using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguracionCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adquisiciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adquisiciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MateriaPrimaAdapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
                    UnidadMedida = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaPrimaAdapter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MateriaPrimaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioDeCompra = table.Column<double>(type: "REAL", nullable: false),
                    AdquisicionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Adquisiciones_AdquisicionId",
                        column: x => x.AdquisicionId,
                        principalTable: "Adquisiciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compras_MateriaPrimaAdapter_MateriaPrimaId",
                        column: x => x.MateriaPrimaId,
                        principalTable: "MateriaPrimaAdapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_AdquisicionId",
                table: "Compras",
                column: "AdquisicionId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_MateriaPrimaId",
                table: "Compras",
                column: "MateriaPrimaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Adquisiciones");

            migrationBuilder.DropTable(
                name: "MateriaPrimaAdapter");
        }
    }
}
