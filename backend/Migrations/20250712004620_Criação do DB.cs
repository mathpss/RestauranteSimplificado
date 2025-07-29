using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CriaçãodoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cardapios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mistura = table.Column<string>(type: "text", nullable: false),
                    Guarnicao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pedidoEntregas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    NomeRua = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    NumeroRua = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Cidade = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidoEntregas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pedidoRetiradas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidoRetiradas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cardapios",
                columns: new[] { "Id", "Guarnicao", "Mistura" },
                values: new object[] { 1, "Legumes Refogado, Abóbora Cabutia, Repolho Refogado, Salada de Ovo c/ Maionese, Batata Palha, Macarrão Alho e Óleo, Farofa do Cheff", "Isca de Carne, Calabresa Acebolada, Linguiça Tosacana Frita, Parmegiana de Frango, Filé de Frango Empanado, Ovo Frito" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cardapios");

            migrationBuilder.DropTable(
                name: "pedidoEntregas");

            migrationBuilder.DropTable(
                name: "pedidoRetiradas");
        }
    }
}
