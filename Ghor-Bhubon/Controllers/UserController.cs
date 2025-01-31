using Ghor_Bhubon.Data;
using Ghor_Bhubon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ghor_Bhubon.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                if (user.PasswordHash != confirmPassword)
                {
                    ModelState.AddModelError("PasswordHash", "Password and Confirm Password must match.");
                    return View(user);
                }

                // Explicitly set the role based on the value
                user.Role = (UserRole)Enum.Parse(typeof(UserRole), user.Role.ToString());

                // Add user to the database
                user.CreatedAt = DateTime.Now;
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(user);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
            if (user != null)
            {
                // You could consider using a session or a cookie to track logged-in users
                return RedirectToAction("Dashboard", "Home");
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

    }
}
