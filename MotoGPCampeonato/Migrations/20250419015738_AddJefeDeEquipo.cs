using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    /// <inheritdoc />
    public partial class AddJefeDeEquipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JefesDeEquipo",
                columns: table => new
                {
                    JefeDeEquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JefesDeEquipo", x => x.JefeDeEquipoId);
                    table.ForeignKey(
                        name: "FK_JefesDeEquipo_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JefesDeEquipo_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JefesDeEquipo_EquipoId",
                table: "JefesDeEquipo",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_JefesDeEquipo_UsuarioId",
                table: "JefesDeEquipo",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JefesDeEquipo");
        }
    }
}
