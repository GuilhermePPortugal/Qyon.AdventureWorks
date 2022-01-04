using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Qyon.AdventureWorks.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competidores",
                columns: table => new
                {
                    Id_Competidores = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Sexo = table.Column<char>(type: "character(1)", nullable: false),
                    TemperaturaMediaCorpo = table.Column<decimal>(type: "numeric", nullable: false),
                    Peso = table.Column<decimal>(type: "numeric", nullable: false),
                    Altura = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competidores", x => x.Id_Competidores);
                });

            migrationBuilder.CreateTable(
                name: "PistaCorrida",
                columns: table => new
                {
                    Id_PistaCorrida = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PistaCorrida", x => x.Id_PistaCorrida);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoCorrida",
                columns: table => new
                {
                    Id_Historico = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Competidores = table.Column<int>(type: "integer", nullable: false),
                    Id_PistaCorrida = table.Column<int>(type: "integer", nullable: false),
                    DataCorrida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TempoGasto = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoCorrida", x => x.Id_Historico);
                    table.ForeignKey(
                        name: "FK_HistoricoCorrida_Competidores_Id_Competidores",
                        column: x => x.Id_Competidores,
                        principalTable: "Competidores",
                        principalColumn: "Id_Competidores",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoCorrida_PistaCorrida_Id_PistaCorrida",
                        column: x => x.Id_PistaCorrida,
                        principalTable: "PistaCorrida",
                        principalColumn: "Id_PistaCorrida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCorrida_Id_Competidores",
                table: "HistoricoCorrida",
                column: "Id_Competidores");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCorrida_Id_PistaCorrida",
                table: "HistoricoCorrida",
                column: "Id_PistaCorrida");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoCorrida");

            migrationBuilder.DropTable(
                name: "Competidores");

            migrationBuilder.DropTable(
                name: "PistaCorrida");
        }
    }
}
