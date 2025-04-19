using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;

namespace MotoGPCampeonato.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MotoGPDbContext _context;

        public HomeController(ILogger<HomeController> logger, MotoGPDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<IActionResult> IndexAsync()
        {
            if (HttpContext.Session.GetInt32("UsuarioId") == null)
                return RedirectToAction("Login", "Account");
            
            var proximaCarrera = await _context.Carreras
            .Where(c => c.Fecha > DateTime.Today)
            .OrderBy(c => c.Fecha)
            .Include(c => c.GranPremio)
            .FirstOrDefaultAsync();

            ViewBag.ProximaCarrera = proximaCarrera;
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
