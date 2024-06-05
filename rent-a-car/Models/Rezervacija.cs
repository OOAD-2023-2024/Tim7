using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car.Models
{
    public class Rezervacija
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public DateTime DatumPreuzimanja { get; set; }
        public DateTime DatumPovratka { get; set; }
        public double Iznos { get; set; }

        [ForeignKey("Vozilo")]
        public int VoziloId { get; set; }
        [ForeignKey("AspNetUser")]
        public String NarucilacId { get; set; }
        public VrstaPlacanja VrstaPlacanja { get; set; }
        [ForeignKey("Placanje")]
        public int PlacanjeId { get; set; }

        public Rezervacija() { }

    }
}
