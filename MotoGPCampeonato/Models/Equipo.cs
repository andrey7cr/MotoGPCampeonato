using System.ComponentModel.DataAnnotations;

namespace MotoGPCampeonato.Models
{
    public class Equipo
    {
        public int EquipoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Fabricante { get; set; }

        [StringLength(50)]
        public string Pais { get; set; }
    }

}
