using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MotoGPCampeonato.Models
{
    public class Pais
    {
        [ValidateNever]
        public int PaisId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }

}
