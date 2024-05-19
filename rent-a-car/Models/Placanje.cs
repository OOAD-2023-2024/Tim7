using System.ComponentModel.DataAnnotations;

namespace rent_a_car.Models
{
    public class Placanje
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumUplate { get; set; }
        public double Iznos { get; set; }
        public String Opis { get; set; }
        public bool ValidnoPlacanje { get; set; }

        public Placanje() { }
    }
}
