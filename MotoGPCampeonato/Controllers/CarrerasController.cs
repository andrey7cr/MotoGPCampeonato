using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;
using X.PagedList.Extensions;



namespace MotoGPCampeonato.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly MotoGPDbContext _context;

        public CarrerasController(MotoGPDbContext context)
        {
            _context = context;
        }

        // GET: Carreras
        public async Task<IActionResult> Index(int? page)
        {
           

            int pageSize = 10;
            int pageNumber = page ?? 1;

            var carrerasQuery = _context.Carreras
                .Include(c => c.GranPremio)
                    .ThenInclude(gp => gp.Circuito)
                        .ThenInclude(c => c.Pais)
                .Include(c => c.Resultados)
                .OrderBy(c => c.Fecha);

            var carrerasPaged = carrerasQuery.ToPagedList(pageNumber, pageSize);

            return View(carrerasPaged);
        }

        // GET: Carreras/Crear
        public async Task<IActionResult> Crear()
        {
            ViewBag.GrandesPremios = new SelectList(
                await _context.GrandesPremios
                    .Include(gp => gp.Circuito)
                    .OrderBy(gp => gp.Nombre)
                    .ToListAsync(),
                "GranPremioId", "Nombre"
            );
            return View();
        }


        // POST: Carreras/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Carrera carrera)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.GrandesPremios = new SelectList(
                    await _context.GrandesPremios
                    .OrderBy(gp => gp.Nombre)
                    .ToListAsync(),
                    "GranPremioId", "Nombre",
                    carrera.GranPremioId
                );

                return View(carrera);
            }

            _context.Carreras.Add(carrera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Carreras/RegistrarResultados/5
        public async Task<IActionResult> RegistrarResultados(int id)
        {
            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return Forbid();

            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null) return NotFound();

            ViewBag.Carrera = carrera;
            ViewBag.Pilotos = await _context.Pilotos.Include(p => p.Equipo).OrderBy(p => p.Nombre).ToListAsync();

            return View();
        }

        // GET: Carreras/Editar/5
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var carrera = await _context.Carreras
                .Include(c => c.GranPremio)
                .FirstOrDefaultAsync(c => c.CarreraId == id);

            if (carrera == null) return NotFound();

            ViewBag.GrandesPremios = new SelectList(
                await _context.GrandesPremios
                    .Include(gp => gp.Circuito)
                    .OrderBy(gp => gp.Nombre)
                    .ToListAsync(),
                "GranPremioId", "Nombre", carrera.GranPremioId
            );

            return View(carrera);
        }


        // POST: Carreras/Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Carrera carrera)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.GrandesPremios = new SelectList(
                    await _context.GrandesPremios
                        .OrderBy(gp => gp.Nombre)
                        .ToListAsync(),
                    "GranPremioId", "Nombre", carrera.GranPremioId
                );
                return View(carrera);
            }

            _context.Update(carrera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return Forbid();

            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null) return NotFound();

            // También se eliminan los resultados asociados
            var resultados = _context.ResultadosCarrera.Where(r => r.CarreraId == id);
            _context.ResultadosCarrera.RemoveRange(resultados);

            _context.Carreras.Remove(carrera);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // POST: Carreras/RegistrarResultados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarResultados(int carreraId, List<int> pilotoIds)
        {
            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return Forbid();

            var carrera = await _context.Carreras.FindAsync(carreraId);
            if (carrera == null) return NotFound();

            for (int i = 0; i < pilotoIds.Count; i++)
            {
                var pilotoId = pilotoIds[i];
                int posicion = i + 1;
                int puntos = ObtenerPuntos(carrera.Tipo, posicion);

                var piloto = await _context.Pilotos.Include(p => p.Equipo).FirstOrDefaultAsync(p => p.PilotoId == pilotoId);
                if (piloto == null) continue;

                // 👉 Asegúrate de guardar los puntos también en ResultadoCarrera
                _context.ResultadosCarrera.Add(new ResultadoCarrera
                {
                    CarreraId = carrera.CarreraId,
                    PilotoId = pilotoId,
                    Posicion = posicion,
                    Puntos = puntos  // 👈 esto faltaba
                });

                piloto.Puntos += puntos;
                piloto.Equipo.Puntos += puntos;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> EditarResultados(int id)
        {
            var carrera = await _context.Carreras
                .Include(c => c.Resultados)
                .Include(c => c.GranPremio)
                    .ThenInclude(gp => gp.Circuito)
                        .ThenInclude(c => c.Pais)
                .FirstOrDefaultAsync(c => c.CarreraId == id);

            if (carrera == null) return NotFound();

            var resultados = await _context.ResultadosCarrera
                .Include(r => r.Piloto)
                    .ThenInclude(p => p.Equipo)
                .Where(r => r.CarreraId == id)
                .OrderBy(r => r.Posicion)
                .ToListAsync();

            ViewBag.Carrera = carrera;
            ViewBag.TodosLosPilotos = await _context.Pilotos
                .Include(p => p.Equipo)
                .OrderBy(p => p.Equipo.Nombre)
                .ThenBy(p => p.Nombre)
                .ToListAsync();

            return View(resultados);
        }


        [HttpPost]
        public async Task<IActionResult> EditarResultados(int carreraId, List<int> pilotoIds)
        {
            var carrera = await _context.Carreras
                .Include(c => c.Resultados)
                .Include(c => c.GranPremio)
                .FirstOrDefaultAsync(c => c.CarreraId == carreraId);

            if (carrera == null || pilotoIds == null || pilotoIds.Count == 0)
                return NotFound();

            // Eliminar resultados anteriores
            _context.ResultadosCarrera.RemoveRange(carrera.Resultados);

            // Agregar nuevos con las posiciones actualizadas
            for (int i = 0; i < pilotoIds.Count; i++)
            {
                var resultado = new ResultadoCarrera
                {
                    CarreraId = carreraId,
                    PilotoId = pilotoIds[i],
                    Posicion = i + 1
                };

                _context.ResultadosCarrera.Add(resultado);
            }

            await _context.SaveChangesAsync();

            // ⚠️ Podés invocar aquí un método que recalcula los puntos
            return RedirectToAction("Index");
        }


        // Lógica de puntos
        private int ObtenerPuntos(TipoCarrera tipo, int posicion)
        {
            if (tipo == TipoCarrera.GP)
            {
                int[] puntosGP = { 25, 20, 16, 13, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
                return (posicion >= 1 && posicion <= 15) ? puntosGP[posicion - 1] : 0;
            }
            else
            {
                int[] puntosSprint = { 12, 9, 7, 6, 5, 4, 3, 2, 1 };
                return (posicion >= 1 && posicion <= 9) ? puntosSprint[posicion - 1] : 0;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerDatosGP(int granPremioId)
        {
            var gp = await _context.GrandesPremios
                .Include(g => g.Circuito)
                .ThenInclude(c => c.Pais)
                .FirstOrDefaultAsync(g => g.GranPremioId == granPremioId);

            if (gp == null) return NotFound();

            return Json(new
            {
                circuito = gp.Circuito.Nombre,
                pais = gp.Circuito.Pais.Nombre
            });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerEventos()
        {
            var carreras = await _context.Carreras
                .Include(c => c.GranPremio)
                .ThenInclude(gp => gp.Circuito)
                .ToListAsync();

            var eventos = carreras.Select(c => new
            {
                title = $"{c.GranPremio?.Nombre} ({c.Tipo})",
                start = c.Fecha.ToString("yyyy-MM-dd"),
                url = Url.Action("Detalles", "Carreras", new { id = c.CarreraId })
            });

            return Json(eventos);
        }

        public IActionResult Calendario()
        {
            return View();
        }

        public async Task<IActionResult> Detalles(int id)
        {
            var carrera = await _context.Carreras
                .Include(c => c.GranPremio)
                    .ThenInclude(gp => gp.Circuito)
                        .ThenInclude(c => c.Pais)
                .Include(c => c.Resultados)
                    .ThenInclude(r => r.Piloto)
                        .ThenInclude(p => p.Equipo)
                .FirstOrDefaultAsync(c => c.CarreraId == id);

            if (carrera == null)
                return NotFound();

            return View(carrera);
        }



    }
}
