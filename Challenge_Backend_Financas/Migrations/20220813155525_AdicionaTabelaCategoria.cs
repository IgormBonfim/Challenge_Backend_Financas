using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge_Backend_Financas.Migrations
{
    public partial class AdicionaTabelaCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "TbReceita",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "TbDespesa",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.CreateTable(
                name: "tbCategoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeCategoria = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoria", x => x.idCategoria);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TbReceita_CategoriaId",
                table: "TbReceita",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbDespesa_CategoriaId",
                table: "TbDespesa",
                column: "CategoriaId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbDespesa_tbCategoria_CategoriaId",
                table: "TbDespesa");

            migrationBuilder.DropForeignKey(
                name: "FK_TbReceita_tbCategoria_CategoriaId",
                table: "TbReceita");

            migrationBuilder.DropTable(
                name: "tbCategoria");

            migrationBuilder.DropIndex(
                name: "IX_TbReceita_CategoriaId",
                table: "TbReceita");

            migrationBuilder.DropIndex(
                name: "IX_TbDespesa_CategoriaId",
                table: "TbDespesa");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "TbReceita");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "TbDespesa");
        }
    }
}
