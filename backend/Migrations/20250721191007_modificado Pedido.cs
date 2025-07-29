using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class modificadoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_PedidoEntregas_PedidoEntregaId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_PedidoRetiradas_PedidoRetiradaId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoRetiradaId",
                table: "Pedidos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoEntregaId",
                table: "Pedidos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_PedidoEntregas_PedidoEntregaId",
                table: "Pedidos",
                column: "PedidoEntregaId",
                principalTable: "PedidoEntregas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_PedidoRetiradas_PedidoRetiradaId",
                table: "Pedidos",
                column: "PedidoRetiradaId",
                principalTable: "PedidoRetiradas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_PedidoEntregas_PedidoEntregaId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_PedidoRetiradas_PedidoRetiradaId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoRetiradaId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoEntregaId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_PedidoEntregas_PedidoEntregaId",
                table: "Pedidos",
                column: "PedidoEntregaId",
                principalTable: "PedidoEntregas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_PedidoRetiradas_PedidoRetiradaId",
                table: "Pedidos",
                column: "PedidoRetiradaId",
                principalTable: "PedidoRetiradas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
