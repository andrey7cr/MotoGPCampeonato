using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;


namespace MotoGPCampeonato.Controllers
{
    public class ResultadosController : Controller
    {
        private readonly MotoGPDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RegistrarResultados(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null) return NotFound();

            ViewBag.Carrera = carrera;
            ViewBag.Pilotos = await _context.Pilotos
                .Include(p => p.Equipo)
                .OrderBy(p => p.Nombre)
                .ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarResultados(int carreraId, List<int> pilotoIds)
        {
            var carrera = await _context.Carreras.FindAsync(carreraId);
            if (carrera == null) return NotFound();

            for (int i = 0; i < pilotoIds.Count; i++)
            {
                int pilotoId = pilotoIds[i];
                int posicion = i + 1;
                int puntos = ObtenerPuntos(carrera.Tipo, posicion);

                var piloto = await _context.Pilotos.Include(p => p.Equipo).FirstOrDefaultAsync(p => p.PilotoId == pilotoId);
                if (piloto == null) continue;

                _context.ResultadosCarrera.Add(new ResultadoCarrera
                {
                    CarreraId = carrera.CarreraId,
                    PilotoId = pilotoId,
                    Posicion = posicion,
                    Puntos = puntos 
                });


                piloto.Puntos += puntos;
                piloto.Equipo.Puntos += puntos;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Carreras");
        }


        private int ObtenerPuntos(TipoCarrera tipo, int posicion)
        {
            if (tipo == TipoCarrera.GP)
            {
                int[] puntosGP = { 25, 20, 16, 13, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
                return (posicion <= 15) ? puntosGP[posicion - 1] : 0;
            }
            else // Sprint
            {
                int[] puntosSprint = { 12, 9, 7, 6, 5, 4, 3, 2, 1 };
                return (posicion <= 9) ? puntosSprint[posicion - 1] : 0;
            }
        }

    }
}
