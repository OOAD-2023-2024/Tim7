using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rent_a_car.Data;
using rent_a_car.Models;
using System.Collections.Specialized;

namespace rent_a_car.Controllers
{
    [Authorize]
    public class VoziloController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VoziloController> _logger;


        public VoziloController(ApplicationDbContext context, ILogger<VoziloController> logger)
        {
            _context = context;
            _logger = logger;
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

        // GET: Vozilo
        public IActionResult Index()
        {
            var vozila = _context.Vozila.ToList();
            return View(vozila);
        }

        // GET: Vozilo/Create
        public IActionResult Create()
        {
            ViewData["TipVozila"] = new SelectList(Enum.GetValues(typeof(TipVozila)).Cast<TipVozila>().Select(v => new { Value = (int)v, Text = v.ToString() }), "Value", "Text");
            ViewData["Transmisija"] = new SelectList(Enum.GetValues(typeof(Transmisija)).Cast<Transmisija>().Select(v => new { Value = (int)v, Text = v.ToString() }), "Value", "Text");
            ViewData["VrstaGoriva"] = new SelectList(Enum.GetValues(typeof(VrstaGoriva)).Cast<VrstaGoriva>().Select(v => new { Value = (int)v, Text = v.ToString() }), "Value", "Text");
            ViewData["TransportniTip"] = new SelectList(Enum.GetValues(typeof(TransportniTip)).Cast<TransportniTip>().Select(v => new { Value = (int)v, Text = v.ToString() }), "Value", "Text");
            ViewData["PutnickiTip"] = new SelectList(Enum.GetValues(typeof(PutnickiTip)).Cast<PutnickiTip>().Select(v => new { Value = (int)v, Text = v.ToString() }), "Value", "Text");
            return View();
        }

        // POST: Vozilo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vozilo model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    Console.WriteLine("Ovo je moja poruka koju želim ispisati u konzoli.");
                    
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while adding Vozilo");
                    ModelState.AddModelError("", "An error occurred while saving the Vozilo.");
                }
            }

            // Ponovno postavljanje dropdown listi u slučaju neuspješne validacije
            ViewData["TipVozila"] = new SelectList(Enum.GetValues(typeof(TipVozila)).Cast<TipVozila>().Select(v => new SelectListItem { Value = ((int)v).ToString(), Text = v.ToString() }), "Value", "Text");
            ViewData["Transmisija"] = new SelectList(Enum.GetValues(typeof(Transmisija)).Cast<Transmisija>().Select(v => new SelectListItem { Value = ((int)v).ToString(), Text = v.ToString() }), "Value", "Text");
            ViewData["VrstaGoriva"] = new SelectList(Enum.GetValues(typeof(VrstaGoriva)).Cast<VrstaGoriva>().Select(v => new SelectListItem { Value = ((int)v).ToString(), Text = v.ToString() }), "Value", "Text");
            ViewData["MaticnaPoslovnicaId"] = new SelectList(_context.Poslovnice, "Id", "Naziv", model.MaticnaPoslovnicaId);

            // Vratite se na isti pogled kako biste prikazali greške validacije
            return View(model);
        }


    }
}


