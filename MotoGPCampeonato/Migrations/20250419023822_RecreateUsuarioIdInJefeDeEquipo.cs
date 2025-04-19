using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    public partial class RecreateUsuarioIdInJefeDeEquipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 👇 AÑADIR LA COLUMNA NUEVAMENTE
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "JefesDeEquipo",
                type: "int",
                nullable: true);

            // 👇 AGREGAR LA FOREIGN KEY
            migrationBuilder.AddForeignKey(
                name: "FK_JefesDeEquipo_Usuarios_UsuarioId",
                table: "JefesDeEquipo",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict); // o Cascade si deseas
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JefesDeEquipo_Usuarios_UsuarioId",
                table: "JefesDeEquipo");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "JefesDeEquipo");
        }
    }
}
