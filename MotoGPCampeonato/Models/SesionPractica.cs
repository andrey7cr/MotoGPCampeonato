using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MotoGPCampeonato.Models
{
    public class SesionPractica
    {
        public int SesionPracticaId { get; set; }

        [Required]
        public int PilotoId { get; set; }

        [ValidateNever]
        public Piloto Piloto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        [Display(Name = "Tiempo por vuelta (s)")]
        public double TiempoVuelta { get; set; }

        [StringLength(250)]
        public string Observaciones { get; set; }
    }
}
