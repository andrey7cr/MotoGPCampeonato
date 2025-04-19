using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;

namespace MotoGPCampeonato.Controllers
{
    public class SesionesPracticaController : Controller
    {
        private readonly MotoGPDbContext _context;

        public SesionesPracticaController(MotoGPDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sesiones = await _context.SesionesPractica
                .Include(s => s.Piloto)
                .ThenInclude(p => p.Equipo)
                .OrderByDescending(s => s.Fecha)
                .ToListAsync();

            return View(sesiones);
        }

        public async Task<IActionResult> Crear()
        {
            ViewBag.Pilotos = new SelectList(await _context.Pilotos.ToListAsync(), "PilotoId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(SesionPractica sesion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Pilotos = new SelectList(await _context.Pilotos.ToListAsync(), "PilotoId", "Nombre", sesion.PilotoId);
                return View(sesion);
            }

            _context.Add(sesion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var sesion = await _context.SesionesPractica.FindAsync(id);
            if (sesion == null) return NotFound();

            ViewBag.Pilotos = new SelectList(await _context.Pilotos.ToListAsync(), "PilotoId", "Nombre", sesion.PilotoId);
            return View(sesion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(SesionPractica sesion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Pilotos = new SelectList(await _context.Pilotos.ToListAsync(), "PilotoId", "Nombre", sesion.PilotoId);
                return View(sesion);
            }

            _context.Update(sesion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            var sesion = await _context.SesionesPractica.FindAsync(id);
            if (sesion == null) return NotFound();

            _context.SesionesPractica.Remove(sesion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
