using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using RentACar.Data;
using RentACar.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace RentACar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Account> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, UserManager<Account> userManager, ILogger<HomeController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                ViewBag.UserName = user.UserName;
                ViewBag.Roles = string.Join(", ", roles);
            }
            else
            {
                ViewBag.UserName = "Not logged in";
                ViewBag.Roles = "None";
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ExploreCars(VoziloPretragaViewModel searchModel)
        {
            var allCars = _context.Vozila.ToList();

            if (!string.IsNullOrEmpty(searchModel.SearchTerm))
            {
                allCars = allCars.Where(c => c.Proizvodjac.Contains(searchModel.SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (searchModel.MinCijena.HasValue)
            {
                allCars = allCars.Where(c => c.Cijena >= searchModel.MinCijena).ToList();
            }

            if (searchModel.MaxCijena.HasValue)
            {
                allCars = allCars.Where(c => c.Cijena <= searchModel.MaxCijena).ToList();
            }

            searchModel.Cars = allCars;
            return View(searchModel);
        }

        public IActionResult CarDetails(int id)
        {
            var car = _context.Vozila.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
    }
}
