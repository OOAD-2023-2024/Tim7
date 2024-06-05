using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Data;
using RentACar.Models;

namespace RentACar.Controllers
{
    [Authorize(Roles = "Dostavljac")]
    public class DostavaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DostavaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult PregledDostava()
        {
            var dostave = _context.Dostave.ToList();
            return View(dostave);
        }

        [HttpPost]
        public IActionResult PrihvatiDostavu(int id)
        {
            var dostava = _context.Dostave.FirstOrDefault(d => d.Id == id);
            if (dostava != null)
            {
                dostava.PrihvatiDostavu();
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(PregledDostava));
        }

        [HttpPost]
        public IActionResult OdbijDostavu(int id)
        {
            var dostava = _context.Dostave.FirstOrDefault(d => d.Id == id);
            if (dostava != null)
            {
                _context.Dostave.Remove(dostava);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(PregledDostava));
        }
    }
}

