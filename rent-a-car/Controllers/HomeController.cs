using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rent_a_car.Data;
using rent_a_car.Models;
using System.Diagnostics;

namespace rent_a_car.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ExploreCars(VoziloPretragaViewModel searchModel)
        {
            // Example static data for demonstration purposes
            var allCars = _context.Vozila.ToList();
        

            // Filter logic
            if (!string.IsNullOrEmpty(searchModel.SearchTerm))
            {
                allCars = allCars.Where(c => c.Proizvodjac.Contains(searchModel.SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if(!string.IsNullOrEmpty(searchModel.SearchTerm) && searchModel.MinCijena.HasValue && searchModel.MaxCijena.HasValue)
            {
                allCars = allCars.Where(c => c.Proizvodjac.Contains(searchModel.SearchTerm, StringComparison.OrdinalIgnoreCase)
                && c.Cijena >= searchModel.MinCijena && c.Cijena <= searchModel.MaxCijena).ToList();
            }

            if (string.IsNullOrEmpty(searchModel.SearchTerm) && searchModel.MinCijena.HasValue && searchModel.MaxCijena.HasValue)
            {
                allCars = allCars.Where(c => c.Cijena >= searchModel.MinCijena && c.Cijena <= searchModel.MaxCijena).ToList();
            }
            else if (searchModel.MinCijena.HasValue && string.IsNullOrEmpty(searchModel.SearchTerm))
            {
                allCars = allCars.Where(c => c.Cijena >= searchModel.MinCijena).ToList();
            }
            else if (searchModel.MaxCijena.HasValue && string.IsNullOrEmpty(searchModel.SearchTerm))
            {
                allCars = allCars.Where(c => c.Cijena <= searchModel.MaxCijena).ToList();
            }

            /*if (!string.IsNullOrEmpty(searchModel.Tip))
            {
                allCars = allCars.Where(c => c.Tip.Equals(searchModel.Tip)).ToList();
            }*/



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

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}*/
