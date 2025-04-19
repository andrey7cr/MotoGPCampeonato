using MotoGPCampeonato.Models;
using Microsoft.EntityFrameworkCore;

namespace MotoGPCampeonato.Data
{
    public class MotoGPDbContext : DbContext
    {
        public MotoGPDbContext(DbContextOptions<MotoGPDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<ResultadoCarrera> ResultadosCarrera { get; set; }
        public DbSet<Circuito> Circuitos { get; set; }
        public DbSet<GranPremio> GrandesPremios { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<JefeDeEquipo> JefesDeEquipo { get; set; }
        public DbSet<SesionPractica> SesionesPractica { get; set; }






    }
}
