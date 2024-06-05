using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data;
using RentACar.Models;
using System;
using System.Threading.Tasks;

namespace RentACar.Controllers
{
    [Authorize]
    public class RezervacijaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Account> _userManager;

        public RezervacijaController(ApplicationDbContext context, UserManager<Account> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRezervacija(RezervacijaViewModel model)
        {
            if (model == null)
            {
                TempData["ErrorMessage"] = "Invalid data.";
                return RedirectToAction("Details", "Vozilo", new { id = model.VoziloId });
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var vozilo = await _context.Vozila.FindAsync(model.VoziloId);
            if (vozilo == null)
            {
                TempData["ErrorMessage"] = "Invalid vehicle.";
                return RedirectToAction("Details", "Vozilo", new { id = model.VoziloId });
            }

            if (!Enum.TryParse(model.VrstaPlacanja, true, out VrstaPlacanja vrstaPlacanja))
            {
                TempData["ErrorMessage"] = "Invalid payment method.";
                return RedirectToAction("Details", "Vozilo", new { id = model.VoziloId });
            }

            if (!vozilo.Dostupno)
            {
                TempData["ErrorMessage"] = "Vozilo nije dostupno u odabranom terminu.";
                return RedirectToAction("Details", "Vozilo", new { id = model.VoziloId });
            }


            var rezervacija = new Rezervacija
            {
                DatumRezervacije = DateTime.Now,
                DatumPreuzimanja = model.DatumPreuzimanja,
                DatumPovratka = model.DatumPovratka,
                Iznos = model.Iznos,
                VoziloId = model.VoziloId,
                Narucilac = user,
                VrstaPlacanja = vrstaPlacanja
            };

            vozilo.Dostupno = false;
            _context.Rezervacije.Add(rezervacija);
            _context.Vozila.Update(vozilo);

            if (model.Dostava != null && !string.IsNullOrEmpty(model.Dostava.Adresa))
            {
                var dostava = new Dostava
                {
                    Narudzba = rezervacija,
                    Adresa = model.Dostava.Adresa,
                    Prihvacena = false
                };
                _context.Dostave.Add(dostava);
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Reservation created successfully.";
            return RedirectToAction("Details", "Vozilo", new { id = model.VoziloId });
        }
    }
}
