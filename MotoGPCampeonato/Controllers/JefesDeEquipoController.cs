using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;

namespace MotoGPCampeonato.Controllers
{
    public class JefesDeEquipoController : Controller
    {
        private readonly MotoGPDbContext _context;

        public JefesDeEquipoController(MotoGPDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var jefes = await _context.JefesDeEquipo
                .Include(j => j.Equipo)
                .ToListAsync();
            return View(jefes);
        }

        public async Task<IActionResult> Crear()
        {
            ViewBag.Equipos = new SelectList(await _context.Equipos.ToListAsync(), "EquipoId", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(JefeDeEquipo jefe)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Equipos = new SelectList(await _context.Equipos.ToListAsync(), "EquipoId", "Nombre", jefe.EquipoId);
                return View(jefe);
            }
            var yaExiste = await _context.JefesDeEquipo.AnyAsync(j => j.EquipoId == jefe.EquipoId);
            if (yaExiste)
            {
                ModelState.AddModelError("", "Este equipo ya tiene un jefe asignado.");
                ViewBag.Equipos = new SelectList(await _context.Equipos.ToListAsync(), "EquipoId", "Nombre", jefe.EquipoId);
                return View(jefe);
            }

            _context.Add(jefe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var jefe = await _context.JefesDeEquipo.FindAsync(id);
            if (jefe == null) return NotFound();

            ViewBag.Equipos = new SelectList(await _context.Equipos.ToListAsync(), "EquipoId", "Nombre", jefe.EquipoId);
            return View(jefe);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(JefeDeEquipo jefe)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Equipos = new SelectList(await _context.Equipos.ToListAsync(), "EquipoId", "Nombre", jefe.EquipoId);
                return View(jefe);
            }

            var yaExiste = await _context.JefesDeEquipo
                .AnyAsync(j => j.EquipoId == jefe.EquipoId && j.JefeDeEquipoId != jefe.JefeDeEquipoId);

            if (yaExiste)
            {
                ModelState.AddModelError("", "Este equipo ya tiene otro jefe asignado.");
                ViewBag.Equipos = new SelectList(await _context.Equipos.ToListAsync(), "EquipoId", "Nombre", jefe.EquipoId);
                return View(jefe);
            }


            _context.Update(jefe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var jefe = await _context.JefesDeEquipo.FindAsync(id);
            if (jefe != null)
            {
                _context.JefesDeEquipo.Remove(jefe);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
