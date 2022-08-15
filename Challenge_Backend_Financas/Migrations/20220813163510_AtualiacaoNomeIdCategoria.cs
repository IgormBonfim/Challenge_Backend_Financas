using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge_Backend_Financas.Migrations
{
    public partial class AtualiacaoNomeIdCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbDespesa_tbCategoria_CategoriaId",
                table: "TbDespesa");

            migrationBuilder.DropForeignKey(
                name: "FK_TbReceita_tbCategoria_CategoriaId",
                table: "TbReceita");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "TbReceita",
                newName: "IdCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_TbReceita_CategoriaId",
                table: "TbReceita",
                newName: "IX_TbReceita_IdCategoria");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "TbDespesa",
                newName: "IdCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_TbDespesa_CategoriaId",
                table: "TbDespesa",
                newName: "IX_TbDespesa_IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_TbDespesa_tbCategoria_IdCategoria",
                table: "TbDespesa",
                column: "IdCategoria",
                principalTable: "tbCategoria",
                principalColumn: "idCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbReceita_tbCategoria_IdCategoria",
                table: "TbReceita",
                column: "IdCategoria",
                principalTable: "tbCategoria",
                principalColumn: "idCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbDespesa_tbCategoria_IdCategoria",
                table: "TbDespesa");

            migrationBuilder.DropForeignKey(
                name: "FK_TbReceita_tbCategoria_IdCategoria",
                table: "TbReceita");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "TbReceita",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_TbReceita_IdCategoria",
                table: "TbReceita",
                newName: "IX_TbReceita_CategoriaId");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "TbDespesa",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_TbDespesa_IdCategoria",
                table: "TbDespesa",
                newName: "IX_TbDespesa_CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbDespesa_tbCategoria_CategoriaId",
                table: "TbDespesa",
                column: "CategoriaId",
                principalTable: "tbCategoria",
                principalColumn: "idCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbReceita_tbCategoria_CategoriaId",
                table: "TbReceita",
                column: "CategoriaId",
                principalTable: "tbCategoria",
                principalColumn: "idCategoria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
