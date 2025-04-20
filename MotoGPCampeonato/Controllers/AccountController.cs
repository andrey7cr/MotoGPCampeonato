using Microsoft.AspNetCore.Mvc;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;



namespace MotoGPCampeonato.Controllers
{
    public class AccountController : Controller
    {

        private readonly MotoGPDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountController(MotoGPDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Correo o contraseña incorrectos.";
            return RedirectToAction("Index", "Home");

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
            // Verifica si el usuario existe
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == email);
            if (usuario == null)
            {
                TempData["Mensaje"] = "No se encontró un usuario con ese correo.";
                return RedirectToAction("Login");
            }

            // Genera y hashea una nueva contraseña temporal
            var nuevaContrasena = Guid.NewGuid().ToString().Substring(0, 8);
            var nuevaContrasenaHasheada = BCrypt.Net.BCrypt.HashPassword(nuevaContrasena);
            usuario.Contrasena = nuevaContrasenaHasheada;
            await _context.SaveChangesAsync();

            // Obtiene configuración SMTP desde appsettings o variables de entorno
            var smtpUser = _configuration["Smtp:User"];
            var smtpPass = _configuration["Smtp:Password"];
            var smtpHost = _configuration["Smtp:Host"];
            var smtpPortStr = _configuration["Smtp:Port"];

            if (string.IsNullOrEmpty(smtpUser) || string.IsNullOrEmpty(smtpPass) ||
                string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(smtpPortStr))
            {
                TempData["Mensaje"] = "Configuración SMTP incompleta. Contacte al administrador.";
                return RedirectToAction("Login");
            }

            if (!int.TryParse(smtpPortStr, out var smtpPort)) smtpPort = 587;

            
            var mail = new MailMessage();
            try
            {
                mail.From = new MailAddress(smtpUser);
                mail.To.Add(email);
                mail.Subject = "Recuperación de contraseña - MotoGP Championship";
                mail.Body = $"Hola {usuario.Nombre},\n\nTu nueva contraseña temporal es: {nuevaContrasena}\n\n" +
                            $"Por favor, inicia sesión y cámbiala lo antes posible.";

                using var smtp = new SmtpClient(smtpHost)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(smtpUser, smtpPass),
                    EnableSsl = true
                };

                smtp.Send(mail);
                TempData["Mensaje"] = "Se ha enviado una nueva contraseña temporal al correo registrado.";
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = $"Error al enviar el correo: {ex.Message}";
            }

            return RedirectToAction("Login");
        }




    }

}
