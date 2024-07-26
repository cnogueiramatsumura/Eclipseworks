using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class StartDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "prioridadeTarefa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nivelPrioridade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prioridadeTarefa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projeto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projeto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "statusTarefa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statusTarefa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPerfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPerfil", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    perfilid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_UsuarioPerfil_perfilid",
                        column: x => x.perfilid,
                        principalTable: "UsuarioPerfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoTarefas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statusAtual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    dtAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoTarefas", x => x.id);
                    table.ForeignKey(
                        name: "FK_HistoricoTarefas_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tarefa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projetoId = table.Column<int>(type: "int", nullable: false),
                    prioridadeId = table.Column<int>(type: "int", nullable: false),
                    statusId = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarefa", x => x.id);
                    table.ForeignKey(
                        name: "FK_tarefa_prioridadeTarefa_prioridadeId",
                        column: x => x.prioridadeId,
                        principalTable: "prioridadeTarefa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tarefa_projeto_projetoId",
                        column: x => x.projetoId,
                        principalTable: "projeto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tarefa_statusTarefa_statusId",
                        column: x => x.statusId,
                        principalTable: "statusTarefa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tarefa_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "UsuarioPerfil",
                columns: new[] { "id", "descricao" },
                values: new object[,]
                {
                    { 1, "Analista" },
                    { 2, "Gerente" }
                });

            migrationBuilder.InsertData(
                table: "prioridadeTarefa",
                columns: new[] { "id", "nivelPrioridade" },
                values: new object[,]
                {
                    { 1, "baixa" },
                    { 2, "media" },
                    { 3, "alta" }
                });

            migrationBuilder.InsertData(
                table: "statusTarefa",
                columns: new[] { "id", "descricao" },
                values: new object[,]
                {
                    { 1, "pendente" },
                    { 2, "em andamento" },
                    { 3, "concluída" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoTarefas_usuarioId",
                table: "HistoricoTarefas",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tarefa_prioridadeId",
                table: "tarefa",
                column: "prioridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_tarefa_projetoId",
                table: "tarefa",
                column: "projetoId");

            migrationBuilder.CreateIndex(
                name: "IX_tarefa_statusId",
                table: "tarefa",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_tarefa_usuarioId",
                table: "tarefa",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_perfilid",
                table: "usuario",
                column: "perfilid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoTarefas");

            migrationBuilder.DropTable(
                name: "tarefa");

            migrationBuilder.DropTable(
                name: "prioridadeTarefa");

            migrationBuilder.DropTable(
                name: "projeto");

            migrationBuilder.DropTable(
                name: "statusTarefa");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "UsuarioPerfil");
        }
    }
}
