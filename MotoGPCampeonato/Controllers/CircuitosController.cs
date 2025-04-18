using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;

namespace MotoGPCampeonato.Controllers
{
    public class CircuitosController : Controller
    {
        private readonly MotoGPDbContext _context;

        public CircuitosController(MotoGPDbContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.Circuitos.ToListAsync());

        public IActionResult Crear() {
            ViewBag.Paises = new SelectList(_context.Paises, "PaisId", "Nombre");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Circuito circuito)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Paises = new SelectList(await _context.Paises.ToListAsync(), "PaisId", "Nombre", circuito.PaisId);
                return View(circuito);
            }

            _context.Add(circuito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Editar(int id)
        {
            var circuito = await _context.Circuitos.FindAsync(id);
            ViewBag.Paises = new SelectList(_context.Paises, "PaisId", "Nombre");
            return circuito == null ? NotFound() : View(circuito);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Circuito c)
        {
            if (!ModelState.IsValid) return View(c);
            _context.Update(c); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var circuito = await _context.Circuitos.FindAsync(id);
            _context.Circuitos.Remove(circuito); await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}
