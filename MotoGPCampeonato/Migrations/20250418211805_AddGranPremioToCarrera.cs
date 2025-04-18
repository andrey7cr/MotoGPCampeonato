using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    /// <inheritdoc />
    public partial class AddGranPremioToCarrera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreCircuito",
                table: "Carreras");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Carreras");

            migrationBuilder.AddColumn<int>(
                name: "GranPremioId",
                table: "Carreras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carreras_GranPremioId",
                table: "Carreras",
                column: "GranPremioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carreras_GrandesPremios_GranPremioId",
                table: "Carreras",
                column: "GranPremioId",
                principalTable: "GrandesPremios",
                principalColumn: "GranPremioId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carreras_GrandesPremios_GranPremioId",
                table: "Carreras");

            migrationBuilder.DropIndex(
                name: "IX_Carreras_GranPremioId",
                table: "Carreras");

            migrationBuilder.DropColumn(
                name: "GranPremioId",
                table: "Carreras");

            migrationBuilder.AddColumn<string>(
                name: "NombreCircuito",
                table: "Carreras",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Carreras",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
