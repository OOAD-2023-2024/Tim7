using Microsoft.AspNetCore.Mvc;
using rent_a_car.Models;
using System.Diagnostics;

namespace rent_a_car.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
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
            var allCars = new List<Vozilo>
        {
            new Vozilo { Id = 1, Proizvodjac = "Audi", Model = "A3", Cijena = 40, Slika = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-OD1NJlzjDxMWjL-LUWN3914SDL7xFgXfrL0WX0wK3w&s", Opis = "jeeeeea", Tip = "Putnicko vozilo", RegistarskeTablice = "09g-776-56h", Navigacija = true, Transmisija = Transmisija.AUTOMATIK, Gorivo = VrstaGoriva.DIZEL  },
            new Vozilo { Id = 2, Proizvodjac = "Mercedes", Model = "SLK", Cijena = 50, Slika = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/15/Mercedes_SLK_200_Kompressor_front.jpg/1200px-Mercedes_SLK_200_Kompressor_front.jpg", Opis = "jeeeeea", Tip = "Putnicko vozilo", RegistarskeTablice = "0988876-56h", Navigacija = true, Transmisija = Transmisija.AUTOMATIK, Gorivo = VrstaGoriva.DIZEL  },
            new Vozilo { Id = 2, Proizvodjac = "Mercedes", Model = "GLA", Cijena = 80, Slika = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3-3648jvx4VrhZYr-A0Sb48vpIY3rvloEpFlGAzvUnw&s", Opis = "jeeeeea", Tip = "Putnicko vozilo", RegistarskeTablice = "0988876-56h", Navigacija = true, Transmisija = Transmisija.AUTOMATIK, Gorivo = VrstaGoriva.DIZEL  }

        };

            // Filter logic
            if (!string.IsNullOrEmpty(searchModel.SearchTerm))
            {
                allCars = allCars.Where(c => c.Proizvodjac.Contains(searchModel.SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (searchModel.MinCijena.HasValue && searchModel.MaxCijena.HasValue)
            {
                allCars = allCars.Where(c => c.Cijena >= searchModel.MinCijena && c.Cijena <= searchModel.MaxCijena).ToList();
            }
            else if (searchModel.MinCijena.HasValue)
            {
                allCars = allCars.Where(c => c.Cijena >= searchModel.MinCijena).ToList();
            }
            else if (searchModel.MaxCijena.HasValue)
            {
                allCars = allCars.Where(c => c.Cijena <= searchModel.MaxCijena).ToList();
            }

            if (!string.IsNullOrEmpty(searchModel.Tip))
            {
                allCars = allCars.Where(c => c.Tip.Equals(searchModel.Tip, StringComparison.OrdinalIgnoreCase)).ToList();
            }



            searchModel.Cars = allCars;

            return View(searchModel);
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
