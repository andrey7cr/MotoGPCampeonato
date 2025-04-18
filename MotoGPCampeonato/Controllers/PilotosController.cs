using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;
using Microsoft.EntityFrameworkCore;


namespace MotoGPCampeonato.Controllers
{
    public class PilotosController : Controller
    {
        private readonly MotoGPDbContext _context;

        public PilotosController(MotoGPDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pilotos = await _context.Pilotos
                .Include(p => p.Equipo)
                .OrderBy(p => p.Equipo.Nombre)    
                .ThenBy(p => p.Nombre)            
                .ToListAsync();

            return View(pilotos);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Equipos = new SelectList(_context.Equipos, "EquipoId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Piloto piloto)
        {
            if (ModelState.IsValid)
            {
                _context.Pilotos.Add(piloto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Equipos = new SelectList(_context.Equipos, "EquipoId", "Nombre", piloto.EquipoId);
            return View(piloto);
        }


        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var piloto = await _context.Pilotos.FindAsync(id);
            if (piloto == null) return NotFound();

            ViewBag.Equipos = new SelectList(_context.Equipos, "EquipoId", "Nombre", piloto.EquipoId);
            return View(piloto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Piloto piloto)
        {
            if (ModelState.IsValid)
            {
                _context.Update(piloto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Equipos = new SelectList(_context.Equipos, "EquipoId", "Nombre", piloto.EquipoId);
            return View(piloto);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var piloto = await _context.Pilotos.FindAsync(id);
            if (piloto != null)
            {
                _context.Pilotos.Remove(piloto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }

}
