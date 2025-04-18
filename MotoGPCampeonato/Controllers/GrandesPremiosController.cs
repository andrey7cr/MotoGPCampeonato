using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;

namespace MotoGPCampeonato.Controllers
{
    public class GrandesPremiosController : Controller
    {
        private readonly MotoGPDbContext _context;

        public GrandesPremiosController(MotoGPDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var gps = await _context.GrandesPremios.Include(g => g.Circuito).ToListAsync();
            ViewBag.Paises = new SelectList(_context.Paises, "PaisId", "Nombre");
            return View(gps);
        }

        public async Task<IActionResult> Crear()
        {
            ViewBag.Circuitos = new SelectList(await _context.Circuitos.ToListAsync(), "CircuitoId", "Nombre");
            ViewBag.Paises = new SelectList(_context.Paises, "PaisId", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(GranPremio gp)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Circuitos = new SelectList(await _context.Circuitos.ToListAsync(), "CircuitoId", "Nombre", gp.CircuitoId);
                return View(gp);
            }
            _context.Add(gp); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var gp = await _context.GrandesPremios.FindAsync(id);
            if (gp == null) return NotFound();

            ViewBag.Paises = new SelectList(
                await _context.Paises.OrderBy(p => p.Nombre).ToListAsync(),
                "PaisId", "Nombre", gp.PaisId
            );
            ViewBag.Circuitos = new SelectList(
                await _context.Circuitos.OrderBy(c => c.Nombre).ToListAsync(),
                "CircuitoId", "Nombre", gp.CircuitoId
            );

            return View(gp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(GranPremio gp)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Circuitos = new SelectList(
                    await _context.Circuitos.OrderBy(c => c.Nombre).ToListAsync(),
                    "CircuitoId", "Nombre", gp.CircuitoId);

                ViewBag.Paises = new SelectList(
                    await _context.Paises.OrderBy(p => p.Nombre).ToListAsync(),
                    "PaisId", "Nombre", gp.PaisId);

                return View(gp);
            }

            try
            {
                _context.Update(gp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Error al guardar el Gran Premio. Verifica que el país y circuito existan.");
                ViewBag.Circuitos = new SelectList(await _context.Circuitos.ToListAsync(), "CircuitoId", "Nombre", gp.CircuitoId);
                ViewBag.Paises = new SelectList(await _context.Paises.ToListAsync(), "PaisId", "Nombre", gp.PaisId);
                return View(gp);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var gp = await _context.GrandesPremios.FindAsync(id);
            _context.GrandesPremios.Remove(gp); await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}
