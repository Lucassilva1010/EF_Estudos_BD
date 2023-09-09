using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dal.Sql.Migrations
{
    public partial class Alterando_o_relacionamentoumpara1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estoqueee_ProdutoId",
                table: "Estoqueee");

            migrationBuilder.CreateIndex(
                name: "IX_Estoqueee_ProdutoId",
                table: "Estoqueee",
                column: "ProdutoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estoqueee_ProdutoId",
                table: "Estoqueee");

            migrationBuilder.CreateIndex(
                name: "IX_Estoqueee_ProdutoId",
                table: "Estoqueee",
                column: "ProdutoId");
        }
    }
}
