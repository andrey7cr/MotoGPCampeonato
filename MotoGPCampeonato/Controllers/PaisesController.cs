using Microsoft.AspNetCore.Mvc;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;

namespace MotoGPCampeonato.Controllers
{
    public class PaisesController : Controller
    {
        private readonly MotoGPDbContext _context;

        public PaisesController(MotoGPDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var paises = _context.Paises
                .OrderBy(p => p.Nombre)
                .ToList();

            return View(paises);
        }


        public IActionResult Crear() => View();

        [HttpPost]
        public async Task<IActionResult> Crear(Pais pais)
        {
            if (!ModelState.IsValid) return View(pais);
            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            var pais = _context.Paises.Find(id);
            return pais == null ? NotFound() : View(pais);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Pais pais)
        {
            if (!ModelState.IsValid) return View(pais);
            _context.Update(pais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais != null)
            {
                _context.Paises.Remove(pais);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
