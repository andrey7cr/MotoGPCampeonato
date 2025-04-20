using Microsoft.AspNetCore.Mvc;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using MotoGPCampeonato.Services;



namespace MotoGPCampeonato.Controllers
{
    public class AccountController : Controller
    {

        private readonly MotoGPDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly EmailService _emailService;

        public AccountController(MotoGPDbContext context, IConfiguration configuration, EmailService emailService)
        {
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
        }


        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View("Registro"); 
        }


        [HttpPost]
        public async Task<IActionResult> Register(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View("Registro", usuario);
        }

        // GET: /Account/Login
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string correo, string contrasena)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
            if (usuario != null && BCrypt.Net.BCrypt.Verify(contrasena, usuario.Contrasena))
            {
                HttpContext.Session.SetInt32("UsuarioId", usuario.UsuarioId);
                HttpContext.Session.SetString("Rol", usuario.Rol.ToString());

                TempData["AnimacionInicio"] = true;

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Correo o contraseña incorrectos.";
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult RecuperarContrasena()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecuperarContrasena(string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == email);
            if (usuario == null)
            {
                TempData["Mensaje"] = "No se encontró un usuario con ese correo.";
                return RedirectToAction("Login");
            }

            // Generar nueva contraseña temporal
            var nuevaContrasena = Guid.NewGuid().ToString().Substring(0, 8);
            usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(nuevaContrasena);
            await _context.SaveChangesAsync();

            try
            {
                // Enviar correo
                await _emailService.SendEmailAsync(
                    email,
                    "Recuperación de contraseña - MotoGP Championship",
                    $"Hola {usuario.Nombre},<br/><br/>Tu nueva contraseña temporal es: <strong>{nuevaContrasena}</strong><br/><br/>Por favor, inicia sesión y cámbiala lo antes posible."
                );

                TempData["Mensaje"] = "Se ha enviado una nueva contraseña al correo registrado.";
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = $"Error al enviar el correo: {ex.Message}";
            }

            TempData["AnimacionInicio"] = true;
            return RedirectToAction("Index", "Home");

        }






    }

}
