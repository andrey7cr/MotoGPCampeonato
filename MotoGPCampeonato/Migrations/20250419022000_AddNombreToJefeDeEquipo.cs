using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    /// <inheritdoc />
    public partial class AddNombreToJefeDeEquipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "JefesDeEquipo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "JefesDeEquipo");
        }
    }
}
