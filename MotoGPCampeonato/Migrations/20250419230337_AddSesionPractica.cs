using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    /// <inheritdoc />
    public partial class AddSesionPractica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SesionesPractica_GrandesPremios_GranPremioId",
                table: "SesionesPractica");

            migrationBuilder.DropIndex(
                name: "IX_SesionesPractica_GranPremioId",
                table: "SesionesPractica");

            migrationBuilder.DropColumn(
                name: "GranPremioId",
                table: "SesionesPractica");

            migrationBuilder.RenameColumn(
                name: "TiempoEnSegundos",
                table: "SesionesPractica",
                newName: "TiempoVuelta");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "SesionesPractica",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "SesionesPractica");

            migrationBuilder.RenameColumn(
                name: "TiempoVuelta",
                table: "SesionesPractica",
                newName: "TiempoEnSegundos");

            migrationBuilder.AddColumn<int>(
                name: "GranPremioId",
                table: "SesionesPractica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SesionesPractica_GranPremioId",
                table: "SesionesPractica",
                column: "GranPremioId");

            migrationBuilder.AddForeignKey(
                name: "FK_SesionesPractica_GrandesPremios_GranPremioId",
                table: "SesionesPractica",
                column: "GranPremioId",
                principalTable: "GrandesPremios",
                principalColumn: "GranPremioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
