using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    /// <inheritdoc />
    public partial class AddPaisToCircuitoAndGranPremio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "Circuitos");

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "GrandesPremios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Circuitos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrandesPremios_PaisId",
                table: "GrandesPremios",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Circuitos_PaisId",
                table: "Circuitos",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Circuitos_Paises_PaisId",
                table: "Circuitos",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "PaisId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrandesPremios_Paises_PaisId",
                table: "GrandesPremios",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "PaisId",
                onDelete: ReferentialAction.NoAction);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Circuitos_Paises_PaisId",
                table: "Circuitos");

            migrationBuilder.DropForeignKey(
                name: "FK_GrandesPremios_Paises_PaisId",
                table: "GrandesPremios");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_GrandesPremios_PaisId",
                table: "GrandesPremios");

            migrationBuilder.DropIndex(
                name: "IX_Circuitos_PaisId",
                table: "Circuitos");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "GrandesPremios");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Circuitos");

            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "Circuitos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
