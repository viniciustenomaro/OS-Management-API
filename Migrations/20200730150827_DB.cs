using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Pass = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Verba = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Acesso = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Salario = table.Column<double>(nullable: false),
                    Hh = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaOrdem",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PessoaId = table.Column<string>(nullable: false),
                    OrdemId = table.Column<string>(nullable: false),
                    Tempo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaOrdem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaOrdem_Ordem_OrdemId",
                        column: x => x.OrdemId,
                        principalTable: "Ordem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaOrdem_pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaOrdem_OrdemId",
                table: "PessoaOrdem",
                column: "OrdemId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaOrdem_PessoaId",
                table: "PessoaOrdem",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "PessoaOrdem");

            migrationBuilder.DropTable(
                name: "Ordem");

            migrationBuilder.DropTable(
                name: "pessoa");
        }
    }
}
