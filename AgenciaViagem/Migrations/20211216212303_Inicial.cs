using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenciaViagem.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cadastrarClientes",
                columns: table => new
                {
                    Id_cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_cliente = table.Column<string>(nullable: true),
                    sobrenome_cliente = table.Column<string>(nullable: true),
                    data_nasc_cliente = table.Column<DateTime>(nullable: false),
                    endereco_cliente = table.Column<string>(nullable: true),
                    telefone_cliente = table.Column<string>(nullable: true),
                    cidade_cliente = table.Column<string>(nullable: true),
                    email_cliente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cadastrarClientes", x => x.Id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "compraClientes",
                columns: table => new
                {
                    Id_compra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_cliente = table.Column<string>(nullable: true),
                    sobrenome_cliente = table.Column<string>(nullable: true),
                    local_partida = table.Column<string>(nullable: true),
                    local_chegada = table.Column<string>(nullable: true),
                    dia_ida = table.Column<DateTime>(nullable: false),
                    dia_chegada = table.Column<DateTime>(nullable: false),
                    qtd_passagem = table.Column<int>(nullable: false),
                    num_assento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compraClientes", x => x.Id_compra);
                });

            migrationBuilder.CreateTable(
                name: "contatoClientes",
                columns: table => new
                {
                    Id_contato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_contato = table.Column<string>(nullable: true),
                    sobrenome_contato = table.Column<string>(nullable: true),
                    telefone_contato = table.Column<string>(nullable: true),
                    cidade_contato = table.Column<string>(nullable: true),
                    regiao_contato = table.Column<string>(nullable: true),
                    email_contato = table.Column<string>(nullable: true),
                    motivo_contato = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatoClientes", x => x.Id_contato);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cadastrarClientes");

            migrationBuilder.DropTable(
                name: "compraClientes");

            migrationBuilder.DropTable(
                name: "contatoClientes");
        }
    }
}
