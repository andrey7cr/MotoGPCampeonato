using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MotoGPCampeonato.Models
{
    public class Circuito
    {
        public int CircuitoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int PaisId { get; set; }
        [ValidateNever]
        public Pais Pais { get; set; }
    }


}
