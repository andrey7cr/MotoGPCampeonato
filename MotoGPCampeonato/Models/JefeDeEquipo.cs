namespace MotoGPCampeonato.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

    public class JefeDeEquipo
    {
        [Key]
        public int JefeDeEquipoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int EquipoId { get; set; }

        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        [ValidateNever]
        public Usuario Usuario { get; set; }

        [ValidateNever]
        public Equipo Equipo { get; set; }
    }


}
