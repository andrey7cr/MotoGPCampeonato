using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;

namespace MotoGPCampeonato.Controllers
{
    public class EquiposController : Controller
    {
        private readonly MotoGPDbContext _context;

        public EquiposController(MotoGPDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var equipos = await _context.Equipos
                .OrderBy(e => e.Nombre) 
                .ToListAsync();

            return View(equipos);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Equipos.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(equipo);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
                return NotFound();

            return View(equipo);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(equipo);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol != "Administrador") return Forbid();

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo != null)
            {
                _context.Equipos.Remove(equipo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }

}
