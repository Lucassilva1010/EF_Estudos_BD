using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dal.Sql.Migrations
{
    public partial class Alterando_o_relacionamento11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstoqueeeProdutoss");

            migrationBuilder.CreateIndex(
                name: "IX_Estoqueee_ProdutoId",
                table: "Estoqueee",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoqueee_Produtoss_ProdutoId",
                table: "Estoqueee",
                column: "ProdutoId",
                principalTable: "Produtoss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoqueee_Produtoss_ProdutoId",
                table: "Estoqueee");

            migrationBuilder.DropIndex(
                name: "IX_Estoqueee_ProdutoId",
                table: "Estoqueee");

            migrationBuilder.CreateTable(
                name: "EstoqueeeProdutoss",
                columns: table => new
                {
                    EstoquesId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueeeProdutoss", x => new { x.EstoquesId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_EstoqueeeProdutoss_Estoqueee_EstoquesId",
                        column: x => x.EstoquesId,
                        principalTable: "Estoqueee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstoqueeeProdutoss_Produtoss_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtoss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueeeProdutoss_ProdutoId",
                table: "EstoqueeeProdutoss",
                column: "ProdutoId");
        }
    }
}
