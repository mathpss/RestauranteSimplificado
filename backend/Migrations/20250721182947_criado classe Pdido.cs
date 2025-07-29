using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class criadoclassePdido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_pedidoRetiradas",
                table: "pedidoRetiradas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pedidoEntregas",
                table: "pedidoEntregas");

            migrationBuilder.DropColumn(
                name: "Pedido",
                table: "pedidoRetiradas");

            migrationBuilder.DropColumn(
                name: "Pedido",
                table: "pedidoEntregas");

            migrationBuilder.RenameTable(
                name: "pedidoRetiradas",
                newName: "PedidoRetiradas");

            migrationBuilder.RenameTable(
                name: "pedidoEntregas",
                newName: "PedidoEntregas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoRetiradas",
                table: "PedidoRetiradas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoEntregas",
                table: "PedidoEntregas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroPedido = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Tamanho = table.Column<string>(type: "text", nullable: false),
                    Guarnicao = table.Column<List<string>>(type: "text[]", nullable: false),
                    Mistura = table.Column<List<string>>(type: "text[]", nullable: false),
                    PedidoEntregaId = table.Column<int>(type: "integer", nullable: false),
                    PedidoRetiradaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_PedidoEntregas_PedidoEntregaId",
                        column: x => x.PedidoEntregaId,
                        principalTable: "PedidoEntregas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_PedidoRetiradas_PedidoRetiradaId",
                        column: x => x.PedidoRetiradaId,
                        principalTable: "PedidoRetiradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PedidoEntregaId",
                table: "Pedidos",
                column: "PedidoEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PedidoRetiradaId",
                table: "Pedidos",
                column: "PedidoRetiradaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoRetiradas",
                table: "PedidoRetiradas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoEntregas",
                table: "PedidoEntregas");

            migrationBuilder.RenameTable(
                name: "PedidoRetiradas",
                newName: "pedidoRetiradas");

            migrationBuilder.RenameTable(
                name: "PedidoEntregas",
                newName: "pedidoEntregas");

            migrationBuilder.AddColumn<string>(
                name: "Pedido",
                table: "pedidoRetiradas",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pedido",
                table: "pedidoEntregas",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedidoRetiradas",
                table: "pedidoRetiradas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedidoEntregas",
                table: "pedidoEntregas",
                column: "Id");
        }
    }
}
