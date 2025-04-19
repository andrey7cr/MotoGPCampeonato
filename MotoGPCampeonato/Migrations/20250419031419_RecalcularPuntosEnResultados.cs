using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoGPCampeonato.Migrations
{
    /// <inheritdoc />
    public partial class RecalcularPuntosEnResultados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // GP (Tipo = 1)
            migrationBuilder.Sql(@"
        UPDATE r
        SET r.Puntos = 
            CASE 
                WHEN r.Posicion = 1 THEN 25
                WHEN r.Posicion = 2 THEN 20
                WHEN r.Posicion = 3 THEN 16
                WHEN r.Posicion = 4 THEN 13
                WHEN r.Posicion = 5 THEN 11
                WHEN r.Posicion = 6 THEN 10
                WHEN r.Posicion = 7 THEN 9
                WHEN r.Posicion = 8 THEN 8
                WHEN r.Posicion = 9 THEN 7
                WHEN r.Posicion = 10 THEN 6
                WHEN r.Posicion = 11 THEN 5
                WHEN r.Posicion = 12 THEN 4
                WHEN r.Posicion = 13 THEN 3
                WHEN r.Posicion = 14 THEN 2
                WHEN r.Posicion = 15 THEN 1
                ELSE 0
            END
        FROM ResultadosCarrera r
        JOIN Carreras c ON r.CarreraId = c.CarreraId
        WHERE c.Tipo = 1
    ");

            // Sprint (Tipo = 0)
            migrationBuilder.Sql(@"
        UPDATE r
        SET r.Puntos = 
            CASE 
                WHEN r.Posicion = 1 THEN 12
                WHEN r.Posicion = 2 THEN 9
                WHEN r.Posicion = 3 THEN 7
                WHEN r.Posicion = 4 THEN 6
                WHEN r.Posicion = 5 THEN 5
                WHEN r.Posicion = 6 THEN 4
                WHEN r.Posicion = 7 THEN 3
                WHEN r.Posicion = 8 THEN 2
                WHEN r.Posicion = 9 THEN 1
                ELSE 0
            END
        FROM ResultadosCarrera r
        JOIN Carreras c ON r.CarreraId = c.CarreraId
        WHERE c.Tipo = 0
    ");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
