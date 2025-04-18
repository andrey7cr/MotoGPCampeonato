using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    /// <inheritdoc />
    public partial class AddGranPremioAndCircuito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Circuitos",
                columns: table => new
                {
                    CircuitoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuitos", x => x.CircuitoId);
                });

            migrationBuilder.CreateTable(
                name: "GrandesPremios",
                columns: table => new
                {
                    GranPremioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CircuitoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandesPremios", x => x.GranPremioId);
                    table.ForeignKey(
                        name: "FK_GrandesPremios_Circuitos_CircuitoId",
                        column: x => x.CircuitoId,
                        principalTable: "Circuitos",
                        principalColumn: "CircuitoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrandesPremios_CircuitoId",
                table: "GrandesPremios",
                column: "CircuitoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrandesPremios");

            migrationBuilder.DropTable(
                name: "Circuitos");
        }
    }
}
