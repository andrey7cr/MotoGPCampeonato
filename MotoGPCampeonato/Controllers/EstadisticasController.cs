using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;
using OfficeOpenXml;
using Spire.Xls;
using System.IO;
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

    private int CalcularPuntosDisputados(Piloto p, int totalCarreras)
    {
        return totalCarreras * 25; // Podés cambiar a 37 si sumás GP + Sprint
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

    // ✅ NUEVO: Genera el archivo Excel físico y retorna la ruta
    private string GenerarExcelEnDisco()
    {
        var datos = _context.Pilotos
            .Include(p => p.Equipo)
            .Select(p => new {
                Piloto = p.Nombre,
                Puntos = p.Puntos,
                Equipo = p.Equipo.Nombre
            }).ToList();

        var rutaTemporal = Path.Combine(Path.GetTempPath(), "EstadisticasPilotos.xlsx");

        
        using var package = new ExcelPackage();
        var hoja = package.Workbook.Worksheets.Add("Estadísticas");
        hoja.Cells.LoadFromCollection(datos, true);
        package.SaveAs(new FileInfo(rutaTemporal));

        return rutaTemporal;
    }

    // ✅ Descarga Excel
    public IActionResult ExportarExcel()
    {
        string excelPath = GenerarExcelEnDisco();
        var fileBytes = System.IO.File.ReadAllBytes(excelPath);
        System.IO.File.Delete(excelPath);

        return File(fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "EstadisticasPilotos.xlsx");
    }

    // ✅ Descarga PDF
    public IActionResult ExportarPdf()
    {
        string excelPath = GenerarExcelEnDisco();
        string pdfPath = ConvertirExcelAPdf(excelPath);
        var fileBytes = System.IO.File.ReadAllBytes(pdfPath);

        System.IO.File.Delete(excelPath);
        System.IO.File.Delete(pdfPath);

        return File(fileBytes, "application/pdf", "Estadisticas.pdf");
    }

    // ✅ Conversión con Spire.XLS
    public string ConvertirExcelAPdf(string excelPath)
    {
        var pdfPath = Path.ChangeExtension(excelPath, ".pdf");
        Workbook workbook = new Workbook();
        workbook.LoadFromFile(excelPath);
        workbook.ConverterSetting.SheetFitToPage = true;
        workbook.SaveToFile(pdfPath, FileFormat.PDF);
        return pdfPath;
    }
}
