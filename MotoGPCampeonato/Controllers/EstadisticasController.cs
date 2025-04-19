using Microsoft.AspNetCore.Mvc;
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

}
