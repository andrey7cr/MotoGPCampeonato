using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    /// <inheritdoc />
    public partial class AddNombreCarreraToCarrera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreCarrera",
                table: "Carreras",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreCarrera",
                table: "Carreras");
        }
    }
}
