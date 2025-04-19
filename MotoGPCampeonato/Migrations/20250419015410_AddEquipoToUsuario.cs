using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipoToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreCarrera",
                table: "Carreras");

            migrationBuilder.AddColumn<int>(
                name: "EquipoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EquipoId",
                table: "Usuarios",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Equipos_EquipoId",
                table: "Usuarios",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "EquipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Equipos_EquipoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EquipoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EquipoId",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "NombreCarrera",
                table: "Carreras",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
