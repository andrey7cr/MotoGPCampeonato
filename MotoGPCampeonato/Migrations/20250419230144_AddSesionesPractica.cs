using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    /// <inheritdoc />
    public partial class AddSesionesPractica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SesionesPractica",
                columns: table => new
                {
                    SesionPracticaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotoId = table.Column<int>(type: "int", nullable: false),
                    GranPremioId = table.Column<int>(type: "int", nullable: false),
                    TiempoEnSegundos = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesionesPractica", x => x.SesionPracticaId);
                    table.ForeignKey(
                        name: "FK_SesionesPractica_GrandesPremios_GranPremioId",
                        column: x => x.GranPremioId,
                        principalTable: "GrandesPremios",
                        principalColumn: "GranPremioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SesionesPractica_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "PilotoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SesionesPractica_GranPremioId",
                table: "SesionesPractica",
                column: "GranPremioId");

            migrationBuilder.CreateIndex(
                name: "IX_SesionesPractica_PilotoId",
                table: "SesionesPractica",
                column: "PilotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SesionesPractica");
        }
    }
}
