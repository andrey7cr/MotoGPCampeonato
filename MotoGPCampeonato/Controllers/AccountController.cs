using Microsoft.AspNetCore.Mvc;
using MotoGPCampeonato.Data;
using MotoGPCampeonato.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;



namespace MotoGPCampeonato.Controllers
{
    public class AccountController : Controller
    {
        private readonly MotoGPDbContext _context;

        public AccountController(MotoGPDbContext context)
        {
            _context = context;
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
    }

}
