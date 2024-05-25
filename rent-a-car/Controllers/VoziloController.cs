using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rent_a_car.Data;
using rent_a_car.Models;

namespace rent_a_car.Controllers
{
    public class VoziloController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoziloController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var vozilo = _context.Vozila.Include(v => v.MaticnaPoslovnicaId).FirstOrDefault(v => v.Id == id);

            if (vozilo == null)
            {
                return NotFound(); // Ako vozilo nije pronađeno, vraćamo 404 Not Found
            }

            // Dohvaćanje povezane poslovnice iz vozila
            var poslovnica = vozilo.MaticnaPoslovnicaId;

            // Provjera je li poslovnica pronađena
            if (poslovnica == null)
            {
                return NotFound(); // Ako poslovnica nije pronađena, vraćamo 404 Not Found
            }

            // Prikazivanje detalja vozila i povezane poslovnice u pogledu
            var model = new DetaljiVozilaViewModel
            {
                Vozilo = vozilo,
                Poslovnica = poslovnica
            };

            return View(model);
        }

    }

}
