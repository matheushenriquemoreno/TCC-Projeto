using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FechamentoPedido.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarinhoCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarinhoCompra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoCarinho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "int", nullable: false),
                    UrlImagePrincipal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoCarinho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCarinho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCarinho = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCarinho_CarinhoCompra_IdCarinho",
                        column: x => x.IdCarinho,
                        principalTable: "CarinhoCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCarinho_ProdutoCarinho_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "ProdutoCarinho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarinho_IdCarinho",
                table: "ItemCarinho",
                column: "IdCarinho");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarinho_IdProduto",
                table: "ItemCarinho",
                column: "IdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCarinho");

            migrationBuilder.DropTable(
                name: "CarinhoCompra");

            migrationBuilder.DropTable(
                name: "ProdutoCarinho");
        }
    }
}
