using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuPonto_Blazor.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaCodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Funcionario_Empresas_EmpresaCodigo",
                        column: x => x.EmpresaCodigo,
                        principalTable: "Empresas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpresaCodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Periodo_Empresas_EmpresaCodigo",
                        column: x => x.EmpresaCodigo,
                        principalTable: "Empresas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ponto",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuncionarioCodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponto", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Ponto_Funcionario_FuncionarioCodigo",
                        column: x => x.FuncionarioCodigo,
                        principalTable: "Funcionario",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tempo = table.Column<TimeSpan>(type: "time", nullable: false),
                    PontoCodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Atividade_Ponto_PontoCodigo",
                        column: x => x.PontoCodigo,
                        principalTable: "Ponto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marcacao",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    Fim = table.Column<TimeSpan>(type: "time", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PontoCodigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcacao", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Marcacao_Ponto_PontoCodigo",
                        column: x => x.PontoCodigo,
                        principalTable: "Ponto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_PontoCodigo",
                table: "Atividade",
                column: "PontoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EmpresaCodigo",
                table: "Funcionario",
                column: "EmpresaCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Marcacao_PontoCodigo",
                table: "Marcacao",
                column: "PontoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Periodo_EmpresaCodigo",
                table: "Periodo",
                column: "EmpresaCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Ponto_FuncionarioCodigo",
                table: "Ponto",
                column: "FuncionarioCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "Marcacao");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropTable(
                name: "Ponto");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
