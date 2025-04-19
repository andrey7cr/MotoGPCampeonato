using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;
using System.Linq;
using System.Threading.Tasks;

public class EstadisticasController : Controller
{
    private readonly MotoGPDbContext _context;

    public EstadisticasController(MotoGPDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> EficienciaPilotos()
    {
        var pilotos = await _context.Pilotos.Include(p => p.Equipo).ToListAsync();
        var totalCarreras = await _context.Carreras.CountAsync();

        var datos = pilotos.Select(p => new
        {
            nombre = p.Nombre,
            puntosObtenidos = p.Puntos,
            puntosDisputados = CalcularPuntosDisputados(p, totalCarreras),
            eficiencia = CalcularEficiencia(p.Puntos, CalcularPuntosDisputados(p, totalCarreras))
        })
        .OrderByDescending(p => p.eficiencia)
        .ToList();

        ViewBag.Nombres = string.Join(",", datos.Select(d => $"'{d.nombre}'"));
        ViewBag.Eficiencia = string.Join(",", datos.Select(d => d.eficiencia.ToString("F2")));

        return View();
    }

    // Asume carrera tipo GP (25 puntos máx)
    private int CalcularPuntosDisputados(Piloto p, int totalCarreras)
    {
        return totalCarreras * 25; // o 37 si considerás GP + Sprint
    }

    private double CalcularEficiencia(int puntosObtenidos, int puntosDisputados)
    {
        return puntosDisputados == 0 ? 0 : (double)puntosObtenidos / puntosDisputados * 100;
    }

    [HttpGet]
    public async Task<IActionResult> PilotoVsPiloto()
    {
        var pilotos = await _context.Pilotos.OrderBy(p => p.Nombre).ToListAsync();
        ViewBag.Pilotos = new SelectList(pilotos, "PilotoId", "Nombre");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> PilotoVsPiloto(int pilotoAId, int pilotoBId)
    {
        var pilotos = await _context.Pilotos.OrderBy(p => p.Nombre).ToListAsync();
        ViewBag.Pilotos = new SelectList(pilotos, "PilotoId", "Nombre");

        var pilotoA = await _context.Pilotos.FirstOrDefaultAsync(p => p.PilotoId == pilotoAId);
        var pilotoB = await _context.Pilotos.FirstOrDefaultAsync(p => p.PilotoId == pilotoBId);

        ViewBag.PilotoANombre = pilotoA?.Nombre ?? "Piloto A";
        ViewBag.PilotoAPuntos = pilotoA?.Puntos ?? 0;

        ViewBag.PilotoBNombre = pilotoB?.Nombre ?? "Piloto B";
        ViewBag.PilotoBPuntos = pilotoB?.Puntos ?? 0;

        return View();
    }

    public async Task<IActionResult> PodiosPorPiloto()
    {
        var podios = await _context.ResultadosCarrera
            .Where(r => r.Posicion <= 3)
            .Include(r => r.Piloto)
            .GroupBy(r => r.Piloto.Nombre)
            .Select(g => new
            {
                Nombre = g.Key,
                Cantidad = g.Count()
            })
            .OrderByDescending(g => g.Cantidad)
            .ToListAsync();

        ViewBag.Nombres = string.Join(",", podios.Select(p => $"'{p.Nombre}'"));
        ViewBag.Cantidades = string.Join(",", podios.Select(p => p.Cantidad));

        return View();
    }



}
