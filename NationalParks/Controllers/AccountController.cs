using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NationalParks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NationalParks.Models.ViewModels;
namespace ArticlesPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() => View();

        public async Task<IActionResult> List()  {

            var users = await _userManager.Users.ToListAsync();
            var usersWithRoles = new List<UserWithRolesViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                usersWithRoles.Add(new UserWithRolesViewModel
                {
                    User = user,
                    Roles = roles.ToList()
                });
            }

            return View(usersWithRoles);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model, string password, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                if (password != confirmPassword)
                {
                    ModelState.AddModelError("", "Las contraseñas no coinciden.");
                    return View(model);
                }

                var user = new User { UserName = model.Email, Email = model.Email, Name = model.Name };
                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, role);
                return Ok("Rol asignado correctamente");
            }
            return NotFound("Usuario no encontrado");
        }


        [HttpGet]
        public IActionResult Login() => View();
        public IActionResult AccessDenied() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, User? user)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
            if (result.Succeeded)
            {
                var foundUser = await _userManager.FindByEmailAsync(email); // Cambié el nombre de 'user' a 'foundUser'
                if (foundUser != null)
                {
                    HttpContext.Session.SetString("UserId", foundUser.Id);
                    HttpContext.Session.SetString("UserName", foundUser.Name);
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Credenciales incorrectas");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            if (HttpContext.Session != null)
            {
                HttpContext.Session.Clear();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
