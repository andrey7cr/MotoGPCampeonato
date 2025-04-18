using MotoGPCampeonato.Models;
using Microsoft.EntityFrameworkCore;

namespace MotoGPCampeonato.Data
{
    public class MotoGPDbContext : DbContext
    {
        public MotoGPDbContext(DbContextOptions<MotoGPDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Equipo> Equipos { get; set; }

    }
}
