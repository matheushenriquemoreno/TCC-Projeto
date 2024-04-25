using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FechamentoPedido.Migrations
{
    /// <inheritdoc />
    public partial class alterandoRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarinho_ProdutoCarinho_IdProduto",
                table: "ItemCarinho");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "ItemCarinho",
                newName: "IdProdutoCarinho");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCarinho_IdProduto",
                table: "ItemCarinho",
                newName: "IX_ItemCarinho_IdProdutoCarinho");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarinho_ProdutoCarinho_IdProdutoCarinho",
                table: "ItemCarinho",
                column: "IdProdutoCarinho",
                principalTable: "ProdutoCarinho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarinho_ProdutoCarinho_IdProdutoCarinho",
                table: "ItemCarinho");

            migrationBuilder.RenameColumn(
                name: "IdProdutoCarinho",
                table: "ItemCarinho",
                newName: "IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCarinho_IdProdutoCarinho",
                table: "ItemCarinho",
                newName: "IX_ItemCarinho_IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarinho_ProdutoCarinho_IdProduto",
                table: "ItemCarinho",
                column: "IdProduto",
                principalTable: "ProdutoCarinho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
