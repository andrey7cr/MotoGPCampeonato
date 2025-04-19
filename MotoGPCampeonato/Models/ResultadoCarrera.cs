namespace MotoGPCampeonato.Models
{
    public class ResultadoCarrera
    {
        public int ResultadoCarreraId { get; set; }

        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }

        public int PilotoId { get; set; }
        public Piloto Piloto { get; set; }

        public int Posicion { get; set; }

        public int Puntos { get; set; }
    }

}
