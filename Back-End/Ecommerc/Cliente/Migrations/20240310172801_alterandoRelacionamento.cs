using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cliente.Migrations
{
    /// <inheritdoc />
    public partial class alterandoRelacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Endereco_IdEndereco",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdEndereco",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "IdEndereco",
                table: "Cliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdEndereco",
                table: "Cliente",
                column: "IdEndereco",
                unique: true,
                filter: "[IdEndereco] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Endereco_IdEndereco",
                table: "Cliente",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Endereco_IdEndereco",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdEndereco",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "IdEndereco",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdEndereco",
                table: "Cliente",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Endereco_IdEndereco",
                table: "Cliente",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
