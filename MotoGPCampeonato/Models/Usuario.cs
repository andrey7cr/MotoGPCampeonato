using System.ComponentModel.DataAnnotations;

namespace MotoGPCampeonato.Models
{
    public enum RolUsuario
    {
        Administrador,
        JefeDeEquipo,
        Piloto
    }

    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Contrasena { get; set; }

        [Required]
        public RolUsuario Rol { get; set; }
        public int? EquipoId { get; set; } 
        public Equipo? Equipo { get; set; }


    }

}
