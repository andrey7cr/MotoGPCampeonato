using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace MotoGPCampeonato.Models
{
    public enum TipoCarrera
    {
        Sprint,
        GP
    }

    public class Carrera
    {
        public int CarreraId { get; set; }

        [Required]
        public int GranPremioId { get; set; }
        [ValidateNever]
        public GranPremio GranPremio { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TipoCarrera Tipo { get; set; }

        [ValidateNever]
        public List<ResultadoCarrera> Resultados { get; set; }
    }



}
