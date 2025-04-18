using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MotoGPCampeonato.Models
{
    public class Piloto
    {
        public int PilotoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int EquipoId { get; set; }

        [ValidateNever] 
        public Equipo Equipo { get; set; }
    }


}
